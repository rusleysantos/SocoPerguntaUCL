using System;
using System.Threading.Tasks;
using Domain.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.DTO;
using Service.Contracts;

namespace PerguntaSocoApi.Controllers
{

    [Route("api/inicio")]
    public class InicioJogoController : Controller
    {

        private IInicioJogoService _service { get; }

        public InicioJogoController(IInicioJogoService service)
        {
            _service = service;
        }

        [HttpPost("iniciar-jogo")]
        [Authorize]
        public async Task<IActionResult> IniciarJogo([FromQuery] int idUsuario, int idCategoria)
        {

            try
            {
                return Ok(new MessageReturn("Sucesso ao Iniciar Partida",
                                            "",
                                            true,
                                            await _service.IniciarJogo(idUsuario, idCategoria)));
            }
            catch
            {

                return BadRequest(new MessageReturn("Erro",
                                                      "Erro, por favor tente novamente mais tarde.",
                                                      false));

            }

        }

        [HttpPost("adicionar-jogador")]
        [Authorize]
        public async Task<IActionResult> AdicionarJogador([FromBody] SessaoDTO sessao)
        {

            try
            {
                return Ok(new MessageReturn("Sucesso ao Entrar na Partida",
                                            "",
                                            true,
                                            await _service.AdicionarParticipante(sessao)));

            }
            catch (Exception e)
            {
                return BadRequest(new MessageReturn("Erro",
                                                      "Erro, por favor tente novamente mais tarde.",
                                                      false));
            }

        }

        [HttpGet("listar-partidas")]
        //[Authorize]
        public async Task<IActionResult> ListarPartidas()
        {

            try
            {
                return Ok(new MessageReturn("Sucesso ao Listar Partidas",
                                            "",
                                            true,
                                            await _service.ListarPartidas()));

            }
            catch (Exception e)
            {
                return BadRequest(new MessageReturn("Erro",
                                                    "Erro, por favor tente novamente mais tarde.",
                                                    false));
            }

        }

    }
}
