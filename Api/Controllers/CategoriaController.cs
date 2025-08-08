using Aplicacao.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IAplicCategoria _aplic;
        public CategoriaController(IAplicCategoria aplic)
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
