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
    public class InicioJogoRepository : IInicioJogoRepository
    {

        private Context _con { get; set; }

        public InicioJogoRepository(Context con)
        {
            _con = con;
        }

        public async Task<InfoJogoDTO> IniciarJogo(int idUsuario, int idCategoria)
        {
            try
            {
                var placar = new Placar
                {
                    Pontuacao = 0,
                    QtdTapaDado = 0,
                    QtdTapaRecebido = 0,
                    idUsuario = idUsuario
                };
                await _con.PLACARES.AddAsync(placar);
                _con.SaveChanges();

                var status = new Status
                {
                    Ativa = true,
                    idPlacar = placar.idPlacar,
                    VezResponder = true
                };

                await _con.STATUS.AddAsync(status);
                _con.SaveChanges();

                var partida = new Partida
                {
                    DataHoraInicio = DateTime.Now,
                    idCategoria = idCategoria
                };

                await _con.PARTIDAS.AddAsync(partida);
                _con.SaveChanges();

                await _con.SESSOES.AddAsync(new Sessao
                {
                    idUsuario = idUsuario,
                    idPartida = partida.idPartida,
                    idStatus = status.idStatus
                });

                _con.SaveChanges();

                InfoJogoDTO info = new InfoJogoDTO
                {
                    Ativa = true,
                    InfoMensagem = "Sucesso ao iniciar partida",
                    idPartida = partida.idPartida,
                    InfoJogador = new InfoJogadorDTO
                    {
                        QtdTapaDado = 0,
                        QtdTapaRecebido = 0,
                        Pontuacao = 0
                    }
                };

                return info;
            }
            catch
            {
                InfoJogoDTO info = new InfoJogoDTO
                {
                    Ativa = true,
                    InfoMensagem = "Não foi possível adicionar o jogador!",
                    InfoJogador = new InfoJogadorDTO
                    {
                        QtdTapaDado = 0,
                        QtdTapaRecebido = 0,
                        Pontuacao = 0
                    }
                };

                return info;
            }
        }

        public async Task<InfoJogoDTO> AdicionarParticipante(SessaoDTO sessao)
        {
            var usuario = await _con.USUARIOS.Where(x => x.idUsuario == sessao.idUsuario).FirstAsync();
            var sessaoJogo = await _con.SESSOES.Where(x => x.idPartida == sessao.idPartida).ToListAsync();
            var partida = await _con.PARTIDAS.Where(x => x.idPartida == sessao.idPartida).FirstAsync();

            if (usuario != null && sessaoJogo.Count() <= 2)
            {

                var placar = new Placar
                {
                    idUsuario = sessao.idUsuario,
                    QtdTapaDado = 0,
                    QtdTapaRecebido = 0,
                    Pontuacao = 0
                };

                await _con.PLACARES.AddAsync(placar);
                _con.SaveChanges();

                var status = new Status
                {
                    Ativa = true,
                    idPlacar = placar.idPlacar,
                    VezResponder = false
                };

                await _con.STATUS.AddAsync(status);
                _con.SaveChanges();

                await _con.SESSOES.AddAsync(new Sessao
                {
                    idUsuario = sessao.idUsuario,
                    idPartida = sessao.idPartida,
                    idStatus = status.idStatus,
                });

                _con.SaveChanges();

                InfoJogoDTO info = new InfoJogoDTO
                {
                    Ativa = true,
                    idPartida = sessao.idPartida,
                    InfoJogador = new InfoJogadorDTO
                    {
                        Nome = usuario.Nome,
                        QtdTapaDado = 0,
                        QtdTapaRecebido = 0,
                        Pontuacao = 0
                    },
                    InfoPergunta = new InfoPerguntaDTO
                    {
                        idCategoria = partida.idCategoria.Value,
                    }

                };

                return info;
            }
            else
            {
                InfoJogoDTO info = new InfoJogoDTO
                {
                    Ativa = false,
                    InfoMensagem = "Não foi possível adicionar o jogador!",
                    InfoJogador = new InfoJogadorDTO
                    {
                        QtdTapaDado = 0,
                        QtdTapaRecebido = 0,
                        Pontuacao = 0,
                    }
                };

                return info;
            }
        }

        public async Task<List<PartidaAtivaDTO>> ListarPartidas()
        {

            return await _con.PARTIDAS.Where(x => x.DataHoraFim == new DateTime(0001, 01, 01))
                                .Select(y => new PartidaAtivaDTO
                                {
                                    idPartida = y.idPartida,
                                    Categoria = y.Categoria.Descricao,
                                    InicioPartida = y.DataHoraInicio,
                                    QuantidadeParticipantes = _con.SESSOES.Where(r => r.idPartida == y.idPartida).Count()
                                }).ToListAsync();
        }
    }
}