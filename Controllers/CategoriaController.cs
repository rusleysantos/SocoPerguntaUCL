using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.DTO;
using Service.Contracts;

namespace PerguntaSocoApi.Controllers
{
    [Route("api/categoria")]
    public class CategoriaController : Controller
    {
        private ICategoriaService _service {get;}
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDTO categoria)
        {
            return View();
        }
    }
}
