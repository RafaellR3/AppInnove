using Aplicacao.Pedidos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IAplicPedido _aplic;
        public PedidoController(IAplicPedido aplic)
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

        [Route("{codigoUsuario}/PedidosEmAbertoPorUsuario")]
        [HttpGet]
        public IActionResult PedidosEmAbertoPorUsuario([FromRoute] Guid codigoUsuario)
        {
            try
            {
                var ret = _aplic.PedidosEmAbertoPorUsuario(codigoUsuario);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{codigoUsuario}/PedidosFinalizadosPorUsuario")]
        [HttpGet]
        public IActionResult PedidosFinalizadosPorUsuario([FromRoute] Guid codigoUsuario)
        {
            try
            {
                var ret = _aplic.PedidosFinalizadosPorUsuario(codigoUsuario);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{codigoUsuario}/PedidosPorUsuario")]
        [HttpGet]
        public IActionResult PedidosPorUsuario([FromRoute] Guid codigoUsuario)
        {
            try
            {
                var ret = _aplic.PedidosPorUsuario(codigoUsuario);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] PedidoDto dto)
        {
            try
            {
                _aplic.Novo(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/Confirmar")]
        public IActionResult Confirmar([FromRoute]Guid id)
        {
            try
            {
                _aplic.Confirmar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/Cancelar")]
        public IActionResult Cancelar([FromRoute] Guid id)
        {
            try
            {
                _aplic.Cancelar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/Recusar")]
        public IActionResult Recusar([FromRoute] Guid id)
        {
            try
            {
                _aplic.Recusar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}/Entregar")]
        public IActionResult Entregar([FromRoute] Guid id)
        {
            try
            {
                _aplic.Entregar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/Enviar")]
        public IActionResult Enviar([FromRoute] Guid id)
        {
            try
            {
                _aplic.Enviar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

