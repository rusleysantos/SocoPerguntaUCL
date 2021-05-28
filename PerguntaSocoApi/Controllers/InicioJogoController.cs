using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domains;
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
        public async Task<IActionResult> IniciarJogo([FromQuery] int idUsuario)
        {
            
            try
            {
                return Ok(new MessageReturn("Sucesso ao Iniciar Partida",
                                            "",
                                            true,
                                            await _service.IniciarJogo(idUsuario)));
            }
            catch
            {

                return BadRequest(new MessageReturn("Erro",
                                                      "Erro, por favor tente novamente mais tarde.",
                                                      false));

            }

        }

        [HttpPost("adicionar-jogador")]
        public async Task<IActionResult> AdicionarJogador([FromBody] SessaoDTO sessao)
        {

            try
            {
                return Ok(new MessageReturn("Sucesso ao Entrar na Partida",
                                            "",
                                            true,
                                            await _service.AdicionarParticipante(sessao)));

            }
            catch
            {
                return BadRequest(new MessageReturn("Erro",
                                                      "Erro, por favor tente novamente mais tarde.",
                                                      false));
            }

        }
    }
}
