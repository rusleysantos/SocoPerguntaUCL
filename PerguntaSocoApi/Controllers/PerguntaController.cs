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
    [Route("api/pergunta")]
    public class PerguntaController : Controller
    {
        private IPerguntaService _service { get; }

        public PerguntaController(IPerguntaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] int idCategoria)
        {
            try
            {

                return Ok(new MessageReturn("Sucesso ao Consultar",
                                            "",
                                            true,
                                            await _service.CriarPergunta(idCategoria)));

            }
            catch (Exception e)
            {
                return BadRequest(new MessageReturn("Erro ao Consultar",
                                                   "Erro ao consultar, por favor tente noavmente mais tarde.",
                                                   false));

            }
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] RespostaDTO resposta)
        {
            try
            {

                return Ok(new MessageReturn("Sucesso ao Consultar",
                                            "",
                                            true,
                                            await _service.ValidarResposta(resposta)));

            }
            catch
            {
                return BadRequest(new MessageReturn("Erro ao Consultar",
                                                   "Erro ao consultar, por favor tente noavmente mais tarde.",
                                                   false));

            }
        }

        

    }
}
