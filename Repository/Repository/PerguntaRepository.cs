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

            listOpcoes = await _con
                                .OPCAOES
                                .Where(x => x.Categoria.idCategoria == idCategoria)
                                .Select(
                                        x =>
                                        new OpcaoDTO
                                        {
                                            idOpcao = x.idOpcao,
                                            Descricao = x.Descricao,
                                            idCategoria = x.idCategoria.Value
                                        }
                                ).ToListAsync();

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
                                                        idOpcaoCorreta = 0

                                                    }
                                            )
                                            .FirstOrDefaultAsync();



            pergunta.Add(new PerguntaDTO
            {
                EnunciadoPergunta = enunciado,
                ListaOpcoes = listOpcoes
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
    }
}
