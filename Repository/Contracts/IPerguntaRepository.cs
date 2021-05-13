using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IPerguntaRepository
    {
        public Task<IEnumerable<PerguntaDTO>> CriarPergunta(int idCategoria);
        public Task<bool> ValidarResposta(RespostaDTO resposta);
        public Task<bool> PopularBanco(List<MassaDadosPerguntaDTO> massa);

    }
}
