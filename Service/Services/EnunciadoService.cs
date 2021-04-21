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

namespace Repository.Service
{
    public class EnunciadoService : IEnunciadoService
    {
        private IEnunciadoRepository _repository { get; }

        public EnunciadoService(IEnunciadoRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AlterarEnunciado(EnunciadoDTO enunciado)
        {
            return _repository.AlterarEnunciado(enunciado);
        }

        public Task<IEnumerable<Enunciado>> BuscarEnunciados(int pagina, int quantidade)
        {
            return _repository.BuscarEnunciados(pagina, quantidade);
        }

        public Task<bool> DeletarEnunciado(int idEnunciado)
        {
            return _repository.DeletarEnunciado(idEnunciado);
        }

        public Task<bool> InserirEnunciado(EnunciadoDTO enunciado)
        {
            return _repository.InserirEnunciado(enunciado);
        }
    }
}
