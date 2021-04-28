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

        public async Task<PerguntaDTO> CriarPergunta(int idCategoria)
        {
            List<OpcaoDTO> listOpcoes = new List<OpcaoDTO>();

            return new PerguntaDTO
            {
                EnunciadoPergunta = await _con
                                            .ENUNCIADOS
                                            .Where(x => x.Categoria.idCategoria == idCategoria)
                                            .Select(
                                                    x =>
                                                    new EnunciadoDTO
                                                    {
                                                        idEnunciado = x.idEnunciado,
                                                        Descricao = x.Descricao,
                                                        idCategoria = x.Categoria.idCategoria
                                                    }
                                            ).FirstOrDefaultAsync(),


                ListaOpcoes = await _con
                                    .OPCAOES
                                    .Where(x => x.Categoria.idCategoria == idCategoria)
                                    .Select(
                                            x =>
                                            new OpcaoDTO
                                            {
                                                idOpcao = x.idOpcao,
                                                Descricao = x.Descricao,
                                                idCategoria = x.Categoria.idCategoria
                                            }
                                    ).ToListAsync(),
            };

        }
    }
}
