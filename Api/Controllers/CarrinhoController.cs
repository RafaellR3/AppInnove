using Aplicacao.Carrinhos;
using Aplicacao.Carrinhos.Dto;
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

        [Route("{id}/RecuperarCarrinhoItensPorUsuario")]
        [HttpGet]
        public IActionResult RecuperarCarrinhoItensPorUsuario([FromRoute] Guid id)
        {
            try
            {
                var ret = _aplic.RecuperarCarrinhoItensPorUsuario(id);

                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AdicionarItem")]
        [HttpPost]
        public IActionResult AdicionarItem([FromBody] AdicionarItemCarrinhoDto dto)
        {
            try
            {
                var ret = _aplic.AdicionarItem(dto);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AlterarQuantidadeItem")]
        [HttpPut]
        public IActionResult AlterarQuantidadeItem([FromBody] AlterarQuantItemCarrinhoDto dto)
        {
            try
            {
                var ret = _aplic.AlterarQuantidadeItem(dto);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("RemoverItem/{codigo}")]
        [HttpDelete]
        public IActionResult RemoverItem([FromRoute] Guid codigo)
        {
            try
            {
                var ret = _aplic.RemoverItem(codigo);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("LimparCarrinhoUsuario/{codigoUsuario}")]
        [HttpDelete]
        public IActionResult LimparCarrinhoUsuario([FromRoute] Guid codigoUsuario)
        {
            try
            {
                var ret = _aplic.RemoverItem(codigoUsuario);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
