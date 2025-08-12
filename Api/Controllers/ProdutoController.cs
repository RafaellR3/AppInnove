using Aplicacao.Produtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IAplicProduto _aplic;
        public ProdutoController(IAplicProduto aplic)
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

        [Route("{pesquisar}/Pesquisar")]
        [HttpGet]
        public IActionResult Pesquisar([FromRoute] string pesquisar)
        {
            try
            {
                var ret = _aplic.Pesquisar(pesquisar);

                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}/PesquisarPorId")]
        [HttpGet]
        public IActionResult PesquisarPorId([FromRoute] Guid id)
        {
            try
            {
                var ret = _aplic.PesquisarPorId(id);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}/PesquisarPorCategoria")]
        [HttpGet]
        public IActionResult PesquisarPorCategoria([FromRoute] Guid id)
        {
            try
            {
                var ret = _aplic.PesquisarPorCategoria(id);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
