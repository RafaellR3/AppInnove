using Aplicacao.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IAplicUsuario _aplic;
        public UsuarioController(IAplicUsuario aplic)
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
