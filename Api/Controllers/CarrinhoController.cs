using Aplicacao.Carrinhos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly IAplicCarrinho _aplic;
        public CarrinhoController(IAplicCarrinho aplic)
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
        [Route("{id}/RecuperarPorUsuario")]

        [HttpGet]
        public IActionResult RecuperarProUsuario([FromRoute] Guid id)
        {
            try
            {
                var ret = _aplic.RecuperarPorUsuario(id);

                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
