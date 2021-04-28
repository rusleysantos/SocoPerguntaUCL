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
    public class OpcaoRepository : IOpcaoRepository
    {
        private Context _con { get; set; }

        public OpcaoRepository(Context con)
        {
            _con = con;
        }

        public async Task<bool> AlterarOpcao(OpcaoDTO opcao)
        {
            var returnObj = await _con.OPCAOES.Where(x => x.idCategoria == opcao.idCategoria).FirstAsync();

            if (returnObj != null)
            {
                returnObj.idCategoria = opcao.idCategoria == 0 ? returnObj.idCategoria : opcao.idCategoria;
                returnObj.Descricao = opcao.Descricao == null ? returnObj.Descricao : opcao.Descricao;

                _con.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Opcao>> BuscarOpcoes(int pagina, int quantidade)
        {
            return await _con.OPCAOES
                             .Skip((pagina - 1) * quantidade)
                             .Take(quantidade)
                             .ToListAsync();
        }

        public async Task<bool> DeletarOpcao(int idOpcao)
        {
            var returnObj = await _con.OPCAOES.Where(x => x.idCategoria == idOpcao).FirstAsync();

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

        public async Task<bool> InserirOpcao(OpcaoDTO opcao)
        {
            var obj = new Opcao
            {
                Descricao = opcao.Descricao,
                idCategoria = opcao.idCategoria,
            };

            await _con.OPCAOES.AddAsync(obj);

            _con.SaveChanges();

            return true;
        }
    }
}
