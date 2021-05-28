using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IPerguntaRepository
    {
        public Task<IEnumerable<PerguntaDTO>> CriarPergunta(int idCategoria, int idUsuario, int idPartida);
        public Task<InfoJogoDTO> ValidarResposta(RespostaDTO resposta);
        public Task<bool> PopularBanco(List<MassaDadosPerguntaDTO> massa);

    }
}
