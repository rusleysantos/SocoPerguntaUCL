using Repository.Contracts;
using Repository.DTO;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PerguntaService : IPerguntaService
    {
        private IPerguntaRepository _respository { get; }
        public PerguntaService(IPerguntaRepository respository)
        {
            _respository = respository;
        }

        public Task<PerguntaDTO> CriarPergunta(int idCategoria)
        {
            return _respository.CriarPergunta(idCategoria);
        }
    }
}
