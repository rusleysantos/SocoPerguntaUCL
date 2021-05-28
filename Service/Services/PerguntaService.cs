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

        public Task<IEnumerable<PerguntaDTO>> CriarPergunta(int idCategoria, int idUsuario, int idPartida)
        {
            return _respository.CriarPergunta(idCategoria, idUsuario, idPartida);
        }

        public Task<InfoJogoDTO> ValidarResposta(RespostaDTO resposta)
        {
            return _respository.ValidarResposta(resposta);
        }

        public Task<bool> PopularBanco(List<MassaDadosPerguntaDTO> massa)
        {
            return _respository.PopularBanco(massa);
        }
    }
}
