using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IInicioJogoService
    {
        Task<InfoJogoDTO> IniciarJogo();
        Task<InfoJogoDTO> AdicionarParticipante(SessaoDTO sessao);
    }
}
