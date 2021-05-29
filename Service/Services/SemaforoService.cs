using Repository.Contracts;
using Repository.DTO;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SemaforoService : ISemaforoService
    {
        private ISemaforoRepository _repository { get; }

        public SemaforoService(ISemaforoRepository repository)
        {
            _repository = repository;
        }

        public Task<InfoJogoDTO> FinalizarPartida(int idPartida)
        {
            return _repository.FinalizarPartida(idPartida);
        }

        public Task<InfoJogoDTO> VerificarPartidaAtiva(int idPartida)
        {
            return _repository.VerificarPartidaAtiva(idPartida);
        }

        public Task<InfoJogoDTO> VerificarVezResposta(int idUsuario, int idPartida)
        {
            return _repository.VerificarVezResposta(idUsuario, idPartida);
        }
    }
}
