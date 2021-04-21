using Repository.Contracts;
using Repository.DTO;
using Repository.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _repository { get; }

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        Task<bool> ICategoriaService.AlterarCategoria(CategoriaDTO categoria)
        {
            return _repository.AlterarCategoria(categoria);
        }

        Task<IEnumerable<Categoria>> ICategoriaService.BuscarCategorias(int pagina, int quantidade)
        {
            return _repository.BuscarCategorias(pagina, quantidade);
        }

        Task<bool> ICategoriaService.DeletarCategoria(int idCategoria)
        {
            return _repository.DeletarCategoria(idCategoria);
        }

        Task<bool> ICategoriaService.InserirCategoria(CategoriaDTO categoria)
        {
            return _repository.InserirCategoria(categoria);
        }
    }
}
