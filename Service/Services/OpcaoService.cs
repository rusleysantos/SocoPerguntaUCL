using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.DTO;
using Repository.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OpcaoService : IOpcaoService
    {
        private IOpcaoRepository _respository { get; }
        public OpcaoService(IOpcaoRepository respository)
        {
            _respository = respository;
        }

        public Task<bool> AlterarOpcao(OpcaoDTO opcao)
        {
            return _respository.AlterarOpcao(opcao);
        }

        public Task<IEnumerable<Opcao>> BuscarOpcoes(int pagina, int quantidade)
        {
            return _respository.BuscarOpcoes(pagina, quantidade);
        }

        public Task<bool> DeletarOpcao(int idOpcao)
        {
            return _respository.DeletarOpcao(idOpcao);
        }

        public Task<bool> InserirOpcao(OpcaoDTO opcao)
        {
            return _respository.InserirOpcao(opcao);
        }
    }
}
