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
    [Route("api/opcao")]
    public class OpcaoController : Controller
    {
        private IOpcaoService _service { get; }

        public OpcaoController(IOpcaoService service)
        {
            _service = service;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post([FromBody] OpcaoDTO opcao)
        {
            try
            {

                if (await _service.InserirOpcao(opcao))
                {
                    return Ok(new MessageReturn("Sucesso ao Cadastrar",
                                                "",
                                                true,
                                                null));

                }
                else
                {
                    return BadRequest(new MessageReturn("Erro",
                                                          "Erro, por favor tente noavmente mais tarde.",
                                                          false));
                }

            }
            catch (Exception e)
            {
                return BadRequest(new MessageReturn("Erro",
                                                   "Erro, por favor tente noavmente mais tarde.",
                                                   false));

            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromQuery] int idOpcao)
        {
            try
            {
                if (await _service.DeletarOpcao(idOpcao))
                {

                    return Ok(new MessageReturn("Sucesso ao Deletar",
                                                "",
                                                true,
                                                null));


                }

                else
                {
                    return BadRequest(new MessageReturn("Erro",
                                                        "Erro, por favor tente noavmente mais tarde.",
                                                        false));
                }
            }

            catch
            {
                return BadRequest(new MessageReturn("Erro",
                                                   "Erro, por favor tente noavmente mais tarde.",
                                                   false));

            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] OpcaoDTO opcao)
        {
            try
            {
                if (await _service.AlterarOpcao(opcao))
                {

                    return Ok(new MessageReturn("Sucesso ao Alterar",
                                                "",
                                                true,
                                                null));


                }
                else
                {
                    return BadRequest(new MessageReturn("Erro",
                                                        "Erro, por favor tente noavmente mais tarde.",
                                                        false));
                }
            }
            catch
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
                                             await _service.BuscarOpcoes(pagina, quantidade)));

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
