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
    public class EnunciadoRepository : IEnunciadoRepository
    {
        private Context _con { get; set; }

        public EnunciadoRepository(Context con)
        {
            _con = con;
        }

        public async Task<bool> AlterarEnunciado(EnunciadoDTO enunciado)
        {
            var returnObj = await _con.ENUNCIADOS.Where(x => x.idCategoria == enunciado.idCategoria).FirstAsync();

            if (returnObj != null)
            {
                returnObj.idCategoria = enunciado.idCategoria == 0 ? returnObj.idCategoria : enunciado.idCategoria;
                returnObj.Descricao = enunciado.Descricao == null ? returnObj.Descricao : enunciado.Descricao;

                _con.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Enunciado>> BuscarEnunciados(int pagina, int quantidade)
        {
            return await _con.ENUNCIADOS
                             .Skip((pagina - 1) * quantidade)
                             .Take(quantidade)
                             .ToListAsync();
        }

        public async Task<bool> DeletarEnunciado(int idEnunciado)
        {
            var returnObj = await _con.ENUNCIADOS.Where(x => x.idCategoria == idEnunciado).FirstAsync();

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

        public async Task<bool> InserirEnunciado(EnunciadoDTO enunciado)
        {
            var obj = new Enunciado
            {
                Descricao = enunciado.Descricao,
                idCategoria = enunciado.idCategoria
            };

            await _con.ENUNCIADOS.AddAsync(obj);

            _con.SaveChanges();

            return true;
        }
    }
}
