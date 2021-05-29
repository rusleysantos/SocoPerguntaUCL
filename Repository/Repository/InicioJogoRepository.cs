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

        public async Task<InfoJogoDTO> IniciarJogo(int idUsuario)
        {
            try
            {
                var placar = new Placar
                {
                    Porntuacao = 0,
                    QtdTapaDado = 0,
                    QtdTapaRecebido = 0,
                    idUsuario = idUsuario
                };
                await _con.PLACARES.AddAsync(placar);
                _con.SaveChanges();

                var status = new Status
                {
                    Ativa = true,
                    idPlacar = placar.idPlacar
                };

                await _con.STATUS.AddAsync(status);
                _con.SaveChanges();

                var partida = new Partida
                {
                    DataHoraInicio = DateTime.Now,
                    idStatus = status.idStatus
                };

                await _con.PARTIDAS.AddAsync(partida);
                _con.SaveChanges();

                await _con.SESSOES.AddAsync(new Sessao
                {
                    idUsuario = idUsuario,
                    idPartida = partida.idPartida
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
            var rodada = await _con.RODADAS.Where(x => x.idPartida == sessao.idPartida)
                                            .Include(y => y.Pergunta)
                                            .FirstAsync();

            if (usuario != null && sessaoJogo.Count() <= 2)
            {

                await _con.SESSOES.AddAsync(new Sessao
                {
                    idUsuario = sessao.idUsuario,
                    idPartida = sessao.idPartida
                });

                await _con.PLACARES.AddAsync(new Placar
                {
                    idUsuario = sessao.idUsuario,
                    QtdTapaDado = 0,
                    QtdTapaRecebido = 0,
                    Porntuacao = 0
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
                        idCategoria = rodada.Pergunta.Enunciado.idCategoria.Value,
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
    }
}