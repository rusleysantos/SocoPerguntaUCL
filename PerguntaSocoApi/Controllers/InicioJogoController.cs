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

    [Route("api/iniciar-jogo")]
    public class InicioJogoController : Controller
    {

        private IInicioJogoService _service { get; }

        public InicioJogoController(IInicioJogoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {

            if (await _service.IniciarJogo())
            {
                return Ok(new MessageReturn("Sucesso ao Iniciar Partida",
                                            "",
                                            true,
                                            null));

            }
            else
            {
                return BadRequest(new MessageReturn("Erro",
                                                      "Erro, por favor tente novamente mais tarde.",
                                                      false));
            }

        }

        [HttpPost("AdicionarJogador")]
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
