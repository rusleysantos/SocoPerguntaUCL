using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace PerguntaSocoApi.Controllers
{
    public class SemaforoController : Controller
    {
        public SemaforoController()
        {

        }

        [HttpGet("verifica-vez-jogador")]
        //[Authorize]
        public async Task<IActionResult> Get([FromQuery] int pagina, int quantidade)
        {
            try
            {

                return Ok(new MessageReturn("Sucesso ao Consultar",
                                            "",
                                            true,
                                             await _service.BuscarOpcoes(pagina, quantidade)));

            }
            catch
            {
                return BadRequest(new MessageReturn("Erro ao Consultar",
                                                   "Erro ao consultar, por favor tente novamente mais tarde.",
                                                   false));

            }
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get([FromQuery] int pagina, int quantidade)
        {
            try
            {

                return Ok(new MessageReturn("Sucesso ao Consultar",
                                            "",
                                            true,
                                             await _service.BuscarOpcoes(pagina, quantidade)));

            }
            catch
            {
                return BadRequest(new MessageReturn("Erro ao Consultar",
                                                   "Erro ao consultar, por favor tente novamente mais tarde.",
                                                   false));

            }
        }
    }
}
