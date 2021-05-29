using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISemaforoService
    {
        Task<InfoJogoDTO> VerificarVezResposta(int idUsuario, int idPartida);
        Task<InfoJogoDTO> VerificarPartidaAtiva(int idPartida);
        Task<InfoJogoDTO> FinalizarPartida(int idPartida);
    }
}
