using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class SemaforoRepository : ISemaforoRepository
    {
        private Context _con { get; set; }

        public SemaforoRepository(Context con)
        {
            _con = con;
        }

        public async Task<InfoJogoDTO> FinalizarPartida(int idPartida)
        {
            var partida = await _con.PARTIDAS.Where(x => x.idPartida == idPartida).FirstAsync();

            partida.DataHoraFim = DateTime.Now;

            _con.PARTIDAS.Update(partida);
            _con.SaveChanges();

            var sessoes = await _con.SESSOES
                                    .Where(x => x.idPartida == idPartida)
                                    .Include(y => y.Status)
                                    .ToListAsync();

            foreach (var sessao in sessoes)
            {
                sessao.Status.Ativa = false;
            }

            _con.SESSOES.UpdateRange(sessoes);
            _con.SaveChanges();

            return new InfoJogoDTO
            {
                Ativa = false,
                idPartida = partida.idPartida,
                InfoMensagem = "Partida Finalizada"
            };
        }

        public async Task<InfoJogoDTO> VerificarPartidaAtiva(int idPartida)
        {
            var sessao = await _con.SESSOES.Where(x => x.idPartida == idPartida)
                                   .Include(y => y.Status)
                                   .FirstAsync();

            return new InfoJogoDTO
            {
                Ativa = sessao.Status.Ativa,
                idPartida = sessao.idPartida.Value,
            };
        }

        public async Task<InfoJogoDTO> VerificarVezResposta(int idUsuario, int idPartida)
        {
            var sessao = await _con.SESSOES.Where(x => x.idPartida == idPartida && x.idUsuario == idUsuario)
                                 .Include(y => y.Status)
                                 .FirstAsync();

            return new InfoJogoDTO
            {
                Ativa = sessao.Status.Ativa,
                idPartida = sessao.idPartida.Value,
                InfoJogador = new InfoJogadorDTO
                {
                    VezResponder = sessao.Status.VezResponder
                }
            };
        }
    }
}
