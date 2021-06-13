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
    public class PerguntaRepository : IPerguntaRepository
    {
        private Context _con { get; set; }

        public PerguntaRepository(Context con)
        {
            _con = con;
        }

        public async Task<IEnumerable<PerguntaDTO>> CriarPergunta(int idUsuario, int idPartida)
        {
            List<OpcaoDTO> listOpcoes = new List<OpcaoDTO>();
            List<PerguntaDTO> perguntas = new List<PerguntaDTO>();
            List<Pergunta> perguntasInsercao = new List<Pergunta>();
            List<Rodada> listaRodadas = new List<Rodada>();

            Random rand = new Random();

            var sessao = await _con.SESSOES.Where(x => x.idPartida == idPartida && x.Status.Placar.idUsuario == idUsuario)
                                    .Include(y => y.Status)
                                        .ThenInclude(r => r.Placar).FirstAsync();

            sessao.Status.VezResponder = true;

            _con.SESSOES.Update(sessao);
            await _con.SaveChangesAsync();

            var partida = await _con.PARTIDAS.Where(x => x.idPartida == idPartida)
                                    .Include(y => y.Categoria)
                                    .FirstAsync();

            EnunciadoDTO enunciado = await _con
                                            .ENUNCIADOS
                                            .Where(x => x.Categoria.idCategoria == partida.idCategoria)
                                            .Select(
                                                    x =>
                                                    new EnunciadoDTO
                                                    {
                                                        idEnunciado = x.idEnunciado,
                                                        Descricao = x.Descricao,
                                                        idCategoria = x.idCategoria.Value,
                                                        idOpcaoCorreta = x.idOpcao.Value
                                                    }
                                            ).OrderBy(r => Guid.NewGuid()).Take(1).FirstAsync();

            listOpcoes = await _con
                                .OPCAOES
                                .Where(x => x.Categoria.idCategoria == partida.idCategoria && x.idOpcao != enunciado.idOpcaoCorreta)
                                .Select(
                                        x =>
                                        new OpcaoDTO
                                        {
                                            idOpcao = x.idOpcao,
                                            Descricao = x.Descricao,
                                            idCategoria = x.idCategoria.Value
                                        }
                                ).OrderBy(r => Guid.NewGuid()).Take(3).ToListAsync();


            listOpcoes.Add(await _con
                                .OPCAOES
                                .Where(x => x.idOpcao == enunciado.idOpcaoCorreta)
                                .Select(
                                        x =>
                                        new OpcaoDTO
                                        {
                                            idOpcao = x.idOpcao,
                                            Descricao = x.Descricao,
                                            idCategoria = x.idCategoria.Value
                                        }
                                ).FirstAsync());

            perguntas.Add(new PerguntaDTO
            {
                EnunciadoPergunta = enunciado,
                ListaOpcoes = listOpcoes.OrderBy(a => rand.Next()).ToList()
            });

            foreach (var pergunta in perguntas)
            {
                foreach (var opcao in pergunta.ListaOpcoes)
                {
                    perguntasInsercao.Add(new Pergunta
                    {
                        idEnunciado = pergunta.EnunciadoPergunta.idEnunciado,
                        idOpcao = opcao.idOpcao
                    });
                }
            }

            await _con.PERGUNTAS.AddRangeAsync(perguntasInsercao);
            await _con.SaveChangesAsync();

            foreach (var rodada in perguntasInsercao)
            {
                listaRodadas.Add(new Rodada
                {
                    idPartida = idPartida,
                    idPergunta = rodada.idPergunta
                });
            }

            await _con.RODADAS.AddRangeAsync(listaRodadas);
            await _con.SaveChangesAsync();

            return perguntas;

        }

        public async Task<InfoJogoDTO> ValidarResposta(RespostaDTO resposta)
        {
            string log = "O jogador {0} {1} a pergunta";

            var info = new InfoJogoDTO
            {
                Ativa = true,
                idPartida = 0,
                InfoPergunta = new InfoPerguntaDTO
                {
                    RespostaJogadorCorreta = false,
                },
                InfoJogador = new InfoJogadorDTO
                {
                    QtdTapaDado = 0,
                    QtdTapaRecebido = 0,
                    Nome = "",
                    Pontuacao = 0
                }
            };

            var enunciado = await _con.ENUNCIADOS
                                    .Where(x => x.idEnunciado == resposta.idEnunciado)
                                    .FirstOrDefaultAsync();

            var opcao = await _con.OPCAOES
                                    .Where(x => x.idOpcao == resposta.idOpcao)
                                    .FirstOrDefaultAsync();

            var partidaUsuario = await _con.SESSOES.Where(x => x.idPartida == resposta.idPartida)
                                                    .Include(y => y.Status)
                                                    .ThenInclude(r => r.Placar)
                                                    .FirstAsync();

            info.InfoJogador.QtdTapaDado = partidaUsuario.Status.Placar.QtdTapaDado;
            info.InfoJogador.QtdTapaRecebido = partidaUsuario.Status.Placar.QtdTapaRecebido;
            info.InfoJogador.Pontuacao = partidaUsuario.Status.Placar.Pontuacao;


            var sessoes = await _con.SESSOES.Where(x => x.idPartida == resposta.idPartida)
                                   .Include(y => y.Status)
                                       .ThenInclude(r => r.Placar)
                                       .ThenInclude(q => q.Usuario).ToListAsync();

            foreach (var sessao in sessoes)
            {
                if (sessao.idUsuario != resposta.idUsuario)
                {
                    sessao.Status.VezResponder = true;
                }
                else
                {
                    sessao.Status.VezResponder = false;
                }

                _con.SESSOES.Update(sessao);
                await _con.SaveChangesAsync();
            }

            if (enunciado.idOpcao == opcao.idOpcao)
            {
                info.InfoPergunta.RespostaJogadorCorreta = true;
                info.InfoJogador.QtdTapaDado++;
                partidaUsuario.Status.Placar.QtdTapaDado++;
                info.InfoJogador.Pontuacao++;
                partidaUsuario.Status.Placar.Pontuacao++;

                _con.SESSOES.Update(partidaUsuario);
                await _con.SaveChangesAsync();

                //_con.LOG_PARTIDA.Add(new LogPartida
                //{
                //    Descricao = String.Format(log,)
                //    idPartida = resposta.idPartida
                //});

                return info;
            }
            else
            {
                info.InfoJogador.QtdTapaRecebido = partidaUsuario.Status.Placar.QtdTapaRecebido++;
                await _con.SaveChangesAsync();

                return info;
            }
        }

        public async Task<bool> PopularBanco(List<MassaDadosPerguntaDTO> massa)
        {
            try
            {
                foreach (var opcao in massa)
                {
                    if (!_con.ENUNCIADOS.Any(x => x.Descricao == opcao.Enunciado))
                    {
                        var novaOpcao = new Opcao
                        {
                            Descricao = opcao.OpcaoCorreta,
                            idCategoria = opcao.idCategoria,
                        };

                        await _con.OPCAOES.AddAsync(novaOpcao);
                        await _con.SaveChangesAsync();

                        var novoEnunciado = new Enunciado
                        {
                            Descricao = opcao.Enunciado,
                            idCategoria = opcao.idCategoria,
                            idOpcao = novaOpcao.idOpcao
                        };

                        await _con.ENUNCIADOS.AddAsync(novoEnunciado);
                        await _con.SaveChangesAsync();

                        List<Opcao> opcoes = new List<Opcao>();
                        foreach (var opcaoErrada in opcao.OpcoesErradas)
                        {

                            opcoes.Add(new Opcao
                            {
                                Descricao = opcaoErrada.Descricao,
                                idCategoria = opcao.idCategoria
                            });


                        }
                        await _con.OPCAOES.AddRangeAsync(opcoes);
                        await _con.SaveChangesAsync();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
