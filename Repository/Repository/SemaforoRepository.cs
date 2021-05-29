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
            var partida = await _con.PARTIDAS.Where(x => x.idPartida == idPartida)
                                    .Include(y => y.Status)
                                    .FirstAsync();

            partida.DataHoraFim = DateTime.Now;
            partida.Status.Ativa = false;

            _con.PARTIDAS.Update(partida);
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
            var partida = await _con.PARTIDAS.Where(x => x.idPartida == idPartida)
                                   .Include(y => y.Status)
                                   .FirstAsync();

            return new InfoJogoDTO
            {
                Ativa = partida.Status.Ativa,
                idPartida = partida.idPartida,
            };
        }

        public async Task<InfoJogoDTO> VerificarVezResposta(int idUsuario, int idPartida)
        {
            var partida = await _con.PARTIDAS.Where(x => x.idPartida == idPartida && x.Status.Placar.idUsuario == idUsuario)
                                 .Include(y => y.Status)
                                     .ThenInclude(r => r.Placar)
                                     .ThenInclude(y => y.Usuario).FirstAsync();

            return new InfoJogoDTO
            {
                Ativa = partida.Status.Ativa,
                idPartida = partida.idPartida,
                InfoJogador = new InfoJogadorDTO
                {
                    idUsuario = partida.Status.Placar.idUsuario.Value,
                    Nome = partida.Status.Placar.Usuario.Nome,
                    VezResponder = partida.Status.VezResponder
                }
            };
        }
    }
}
