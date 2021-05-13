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

        [Authorize]
        [HttpGet]
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


        [Authorize]
        [HttpPost]
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

        [HttpPost("popular")]
        public async Task<IActionResult> PopularBanco([FromBody] List<MassaDadosPerguntaDTO> massa)
        {
            try
            {
                if (await _service.PopularBanco(massa))
                {

                    return Ok(new MessageReturn("Sucesso ao Popular Banco",
                                                "",
                                                true,
                                                ""));

                }
                else
                {
                    return Ok(new MessageReturn("Erro ao Popular Banco",
                                                "",
                                                true,
                                                ""));
                }
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
