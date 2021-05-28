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

        public async Task<IEnumerable<PerguntaDTO>> CriarPergunta(int idCategoria, int idUsuario, int idPartida)
        {
            List<OpcaoDTO> listOpcoes = new List<OpcaoDTO>();
            List<PerguntaDTO> pergunta = new List<PerguntaDTO>();
            Random rand = new Random();

            var partida = await _con.PARTIDAS.Where(x => x.idPartida == idPartida && x.Status.Placar.idUsuario == idUsuario)
                                    .Include(y => y.Status)
                                        .ThenInclude(r => r.Placar).FirstAsync();
            partida.Status.VezResponder = true;

            _con.SaveChanges();

            EnunciadoDTO enunciado = await _con
                                            .ENUNCIADOS
                                            .Where(x => x.Categoria.idCategoria == idCategoria)
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
                                .Where(x => x.Categoria.idCategoria == idCategoria && x.idOpcao != enunciado.idOpcaoCorreta)
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


            pergunta.Add(new PerguntaDTO
            {
                EnunciadoPergunta = enunciado,
                ListaOpcoes = listOpcoes.OrderBy(a => rand.Next()).ToList()
            });

            return pergunta;

        }

        public async Task<InfoJogoDTO> ValidarResposta(RespostaDTO resposta)
        {
            var info = new InfoJogoDTO
            {
                Ativa = true,
                idPartida = 0,
                InfoPergunta = new InfoPerguntaDTO
                {
                    RespostaJogador = false,
                },
                InfoJogador = new InfoJogadorDTO
                {
                    QtdTapaDado = 0,
                    QtdTapaRecebido = 0,
                    Nome = "",
                    Porntuacao = 0
                }
            };

            var enunciado = await _con.ENUNCIADOS
                                    .Where(x => x.idEnunciado == resposta.idEnunciado)
                                    .FirstOrDefaultAsync();

            var opcao = await _con.OPCAOES
                                    .Where(x => x.idOpcao == resposta.idOpcao)
                                    .FirstOrDefaultAsync();

            var partidaUsuario = await _con.PARTIDAS.Where(x => x.idPartida == resposta.idPartida)
                                .Include(y => y.Status)
                                    .ThenInclude(r => r.Placar).FirstAsync();

            info.InfoJogador.QtdTapaDado = partidaUsuario.Status.Placar.QtdTapaDado;
            info.InfoJogador.QtdTapaRecebido = partidaUsuario.Status.Placar.QtdTapaRecebido;
            info.InfoJogador.Porntuacao = partidaUsuario.Status.Placar.Porntuacao;


            var partida = await _con.PARTIDAS.Where(x => x.idPartida == resposta.idPartida &&
                                                     x.Status.Placar.idUsuario == resposta.idUsuario)
                                                      .Include(y => y.Status)
                                                          .ThenInclude(r => r.Placar).FirstAsync();
            partida.Status.VezResponder = false;

            _con.SaveChanges();


            if (enunciado.idOpcao == opcao.idOpcao)
            {
                info.InfoPergunta.RespostaJogador = true;
                info.InfoJogador.QtdTapaDado = partidaUsuario.Status.Placar.QtdTapaDado++;
                info.InfoJogador.Porntuacao = partidaUsuario.Status.Placar.Porntuacao++;

                _con.PARTIDAS.Update(partidaUsuario);
                _con.SaveChanges();

                return info;
            }
            else
            {
                info.InfoJogador.QtdTapaRecebido = partidaUsuario.Status.Placar.QtdTapaRecebido++;
                _con.SaveChanges();

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
                        _con.SaveChanges();

                        var novoEnunciado = new Enunciado
                        {
                            Descricao = opcao.Enunciado,
                            idCategoria = opcao.idCategoria,
                            idOpcao = novaOpcao.idOpcao
                        };

                        await _con.ENUNCIADOS.AddAsync(novoEnunciado);
                        _con.SaveChanges();

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
                        _con.SaveChanges();
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
