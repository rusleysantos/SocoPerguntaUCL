using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IInicioJogoRepository
    {
        Task<InfoJogoDTO> IniciarJogo(int idUsuario);
        Task<InfoJogoDTO> AdicionarParticipante(SessaoDTO sessao);
    }
}
