using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace PerguntaSocoApi.Controllers
{
    [Route("api/pergunta/semaforo")]
    public class SemaforoController : Controller
    {
        private ISemaforoService _service { get; }

        public SemaforoController(ISemaforoService service)
        {
            _service = service;
        }

        [HttpGet("verifica-vez-resposta")]
        [Authorize]
        public async Task<IActionResult> VerificarVezResposta([FromQuery] int idUsuario, int idPartida)
        {
            try
            {

                return Ok(new MessageReturn("Sucesso ao Consultar",
                                            "",
                                            true,
                                             await _service.VerificarVezResposta(idUsuario, idPartida)));
            }
            catch
            {
                return BadRequest(new MessageReturn("Erro ao Consultar",
                                                   "Erro ao consultar, por favor tente novamente mais tarde.",
                                                   false));
            }
        }

        [HttpGet("verifica-partida-ativa")]
        [Authorize]
        public async Task<IActionResult> VerificarPartidaAtiva([FromQuery] int idPartida)
        {
            try
            {

                return Ok(new MessageReturn("Sucesso ao Consultar",
                                            "",
                                            true,
                                             await _service.VerificarPartidaAtiva(idPartida)));

            }
            catch(Exception e)
            {
                return BadRequest(new MessageReturn("Erro ao Consultar",
                                                   "Erro ao consultar, por favor tente novamente mais tarde.",
                                                   false));

            }
        }


        [HttpGet("finaliza-partida")]
        [Authorize]
        public async Task<IActionResult> FinalizarPartida([FromQuery] int idPartida)
        {
            try
            {

                return Ok(new MessageReturn("Sucesso ao Finalizar",
                                            "",
                                            true,
                                             await _service.FinalizarPartida(idPartida)));

            }
            catch
            {
                return BadRequest(new MessageReturn("Erro ao Finalizar",
                                                   "Erro ao consultar, por favor tente novamente mais tarde.",
                                                   false));

            }
        }
    }
}
