using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Contracts;
using Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Repository.DTO;
using Service.Contracts;

namespace TeamNotationAPI.Controllers
{
    [Route("api")]
    public class LoginController : Controller
    {
        private ILoginService _service { get; set; }
        private ITokenService _token { get; set; }
    
        public LoginController(ILoginService service, ITokenService token)
        {
            _service = service;
            _token = token;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                LoginDTO LoginReturn = await _service.Login(login);

                if (LoginReturn.AuthorizationStatus)
                {

                    return Ok(new MessageReturn("Login Efetuado Com Sucesso",
                                                 _token.GenerateToken(LoginReturn),
                                                true));
                }
                else
                {
                    return Ok(new MessageReturn("Senha ou Login Errado",
                                                "",
                                                false));
                }
            }
            catch (Exception e)
            {
                return BadRequest(new MessageReturn("Erro ao Fazer Login",
                                                     "Erro ao realizar login, por favor tente mais tarde.",
                                                     false));
            }
        }
    }
}
