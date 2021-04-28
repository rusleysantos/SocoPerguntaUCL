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
    [Route("api/enunciado")]
    public class EnunciadoController : Controller
    {
        private IEnunciadoService _service { get; }

        public EnunciadoController(IEnunciadoService service)
        {
            _service = service;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post([FromBody] EnunciadoDTO enunciado)
        {
            if (await _service.InserirEnunciado(enunciado))
            {
                try
                {

                    return Ok(new MessageReturn("Sucesso ao Cadastrar",
                                                "",
                                                true,
                                                null));


                }
                catch
                {
                    return BadRequest(new MessageReturn("Erro",
                                                       "Erro, por favor tente noavmente mais tarde.",
                                                       false));

                }
            }
            else
            {
                return BadRequest(new MessageReturn("Erro",
                                                      "Erro, por favor tente noavmente mais tarde.",
                                                      false));
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromQuery] int idEnunciado)
        {
            if (await _service.DeletarEnunciado(idEnunciado))
            {
                try
                {

                    return Ok(new MessageReturn("Sucesso ao Deletar",
                                                "",
                                                true,
                                                null));


                }
                catch
                {
                    return BadRequest(new MessageReturn("Erro",
                                                       "Erro, por favor tente noavmente mais tarde.",
                                                       false));

                }
            }
            else
            {
                return BadRequest(new MessageReturn("Erro",
                                                    "Erro, por favor tente noavmente mais tarde.",
                                                    false));
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] EnunciadoDTO enunciado)
        {
            if (await _service.AlterarEnunciado(enunciado))
            {
                try
                {

                    return Ok(new MessageReturn("Sucesso ao Alterar",
                                                "",
                                                true,
                                                null));


                }
                catch
                {
                    return BadRequest(new MessageReturn("Erro",
                                                       "Erro, por favor tente noavmente mais tarde.",
                                                       false));

                }
            }
            else
            {
                return BadRequest(new MessageReturn("Erro",
                                                    "Erro, por favor tente noavmente mais tarde.",
                                                    false));
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] int pagina, int quantidade)
        {
            try
            {

                return Ok(new MessageReturn("Sucesso ao Consultar",
                                            "",
                                            true,
                                             await _service.BuscarEnunciados(pagina, quantidade)));

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
