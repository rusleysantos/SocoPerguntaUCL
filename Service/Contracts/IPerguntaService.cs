using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPerguntaService
    {
        public Task<IEnumerable<PerguntaDTO>> CriarPergunta(int idCategoria);
        public Task<bool> ValidarResposta(RespostaDTO resposta);

    }
}
