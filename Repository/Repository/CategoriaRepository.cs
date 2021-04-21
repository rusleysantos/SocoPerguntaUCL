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
    public class CategoriaRepository : ICategoriaRepository
    {
        private Context _con { get; set; }

        public CategoriaRepository(Context con)
        {
            _con = con;
        }

        public async Task<bool> AlterarCategoria(CategoriaDTO categoria)
        {
            var returnObj = await _con.CATEGORIAS.Where(x => x.idCategoria == categoria.idCategoria).FirstAsync();

            if (returnObj != null)
            {
                returnObj.Descricao = categoria.Descricao == null ? returnObj.Descricao : categoria.Descricao;
                returnObj.Nome = categoria.Nome == null ? returnObj.Nome : categoria.Nome;

                _con.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Categoria>> BuscarCategorias(int pagina, int quantidade)
        {
            return await _con.CATEGORIAS
                               .Skip((pagina - 1) * quantidade)
                               .Take(quantidade)
                               .ToListAsync();
        }

        public async Task<bool> DeletarCategoria(int idCategoria)
        {
            var returnObj = await _con.CATEGORIAS.Where(x => x.idCategoria == idCategoria).FirstAsync();

            if (returnObj != null)
            {
                _con.Remove(returnObj);
                _con.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> InserirCategoria(CategoriaDTO categoria)
        {
            var obj = new Categoria
            {
                Descricao = categoria.Descricao,
                Nome = categoria.Nome
            };

            await _con.CATEGORIAS.AddAsync(obj);

            _con.SaveChanges();

            return true;
        }
    }
}
