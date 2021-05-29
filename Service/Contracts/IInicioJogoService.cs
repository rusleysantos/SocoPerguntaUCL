using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IInicioJogoService
    {
        Task<InfoJogoDTO> IniciarJogo(int idUsuario, int idCategoria);
        Task<InfoJogoDTO> AdicionarParticipante(SessaoDTO sessao);
    }
}
