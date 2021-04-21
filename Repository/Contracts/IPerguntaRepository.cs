using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IPerguntaRepository
    {
        public Task<PerguntaDTO> CriarPergunta(int idCategoria);
    }
}
