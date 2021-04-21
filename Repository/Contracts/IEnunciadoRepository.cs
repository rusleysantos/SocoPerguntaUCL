using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IEnunciadoRepository
    {
        Task<bool> InserirEnunciado(EnunciadoDTO enunciado);
        Task<bool> DeletarEnunciado(int idEnunciado);
        Task<bool> AlterarEnunciado(EnunciadoDTO enunciado);
        Task<IEnumerable<Enunciado>> BuscarEnunciados(int pagina, int quantidade);
    }
}
