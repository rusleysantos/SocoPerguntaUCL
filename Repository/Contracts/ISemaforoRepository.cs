using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface ISemaforoRepository
    {
        Task<InfoJogoDTO> VerificarVezResposta(int idUsuario, int idPartida);
        Task<InfoJogoDTO> VerificarPartidaAtiva(int idPartida);
        Task<InfoJogoDTO> FinalizarPartida(int idPartida);
    }
}
