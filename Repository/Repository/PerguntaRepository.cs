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

        public async Task<IEnumerable<PerguntaDTO>> CriarPergunta(int idCategoria)
        {
            List<OpcaoDTO> listOpcoes = new List<OpcaoDTO>();
            List<PerguntaDTO> pergunta = new List<PerguntaDTO>();
            Random rand = new Random();

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

        public async Task<bool> ValidarResposta(RespostaDTO resposta)
        {
            var enunciado = await _con.ENUNCIADOS
                                    .Where(x => x.idEnunciado == resposta.idEnunciado)
                                    .FirstOrDefaultAsync();

            var opcao = await _con.OPCAOES
                                    .Where(x => x.idOpcao == resposta.idOpcao)
                                    .FirstOrDefaultAsync();

            if (enunciado.idOpcao == opcao.idOpcao)
            {
                return true;
            }
            else
            {
                return false;
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
