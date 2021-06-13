using Repository.Contracts;
using Repository.DTO;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class InicioJogoService : IInicioJogoService
    {
        private IInicioJogoRepository _respository { get; }
        public InicioJogoService(IInicioJogoRepository respository)
        {
            _respository = respository;
        }

        public Task<InfoJogoDTO> IniciarJogo(int idUsuario, int idCategoria)
        {
            return _respository.IniciarJogo(idUsuario, idCategoria);
        }

        public Task<InfoJogoDTO> AdicionarParticipante(SessaoDTO sessao)
        {
            return _respository.AdicionarParticipante(sessao);
        }

        public Task<List<PartidaAtivaDTO>> ListarPartidas()
        {
            return _respository.ListarPartidas();
        }
    }
}
