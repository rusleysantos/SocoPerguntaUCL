using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICategoriaService
    {
        Task<bool> InserirCategoria(CategoriaDTO categoria);
        Task<bool> DeletarCategoria(int idCategoria);
        Task<bool> AlterarCategoria(CategoriaDTO categoria);
        Task<IEnumerable<Categoria>> BuscarCategorias(int pagina, int quantidade);

    }
}
