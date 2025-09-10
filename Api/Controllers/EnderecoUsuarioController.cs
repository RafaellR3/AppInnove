using Aplicacao.Enderecos;
using Aplicacao.Pedidos;
using Dominio.Enderecos;
using Dominio.Enderecos.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoUsuarioController : ControllerBase
    {
        private readonly IAplicEnderecoUsuario _aplic;
        public EnderecoUsuarioController(IAplicEnderecoUsuario aplic)
        {
            _aplic = aplic;
        }

        [HttpGet]
        public IActionResult Recuperar()
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

        [HttpGet("{codigoUsuario}/RecuperarPorUsuario")]
        public IActionResult Recuperar([FromRoute] Guid codigoUsuario)
        {
            try
            {
                var ret = _aplic.RecuperarPorUsuario(codigoUsuario);

                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] EnderecoUsuarioDto dto)
        {
            try
            {
                var ret = _aplic.Novo(dto);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{codigoUsuario}/{codigoEndereco}/DefinirComoPadrao")]
        public IActionResult DefinirComoPadrao([FromRoute] Guid codigoUsuario, Guid codigoEndereco)
        {
            try
            {
                var ret = _aplic.DefinirComoPadrao(codigoUsuario, codigoEndereco);

                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
