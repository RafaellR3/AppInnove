using Aplicacao.Promocoes;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromocaoController : ControllerBase
    {
        private readonly IAplicPromocao _aplic;
        public PromocaoController(IAplicPromocao aplic)
        {
            _aplic = aplic;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var ret = _aplic.Recuperar();

                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
