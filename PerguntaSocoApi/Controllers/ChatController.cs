using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.DTO;
using Service.Contracts;

namespace PerguntaSocoApi.Controllers
{
    [Route("api/chat")]
    public class ChatController : Controller
    {
        private IChatService _service { get; }

        public ChatController(IChatService service)
        {
            _service = service;
        }

        [HttpPost("enviar")]
        //[Authorize]
        public async Task<IActionResult> Enviar([FromBody] ChatDTO chat)
        {

            try
            {
                return Ok(new MessageReturn("Sucesso ao Consultar",
                                            "",
                                            true,
                                            await _service.EnvioMensagem(chat)));
            }
            catch
            {

                return BadRequest(new MessageReturn("Erro",
                                                      "Erro, por favor tente novamente mais tarde.",
                                                      false));

            }

        }

        [HttpPost("receber")]
        //[Authorize]
        public async Task<IActionResult> Receber([FromBody] ChatDTO chat)
        {

            try
            {
                return Ok(new MessageReturn("Sucesso ao Consultar",
                                            "",
                                            true,
                                            await _service.ReceberMensagem(chat)));
            }
            catch(Exception e)
            {

                return BadRequest(new MessageReturn("Erro",
                                                      "Erro, por favor tente novamente mais tarde.",
                                                      false));

            }

        }

    }
}
