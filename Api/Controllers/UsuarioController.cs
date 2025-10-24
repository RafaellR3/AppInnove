using Aplicacao.Usuarios;
using Aplicacao.Usuarios.Dto;
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

        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] CadastrarUsuarioDto dto)
        {
            try
            {
                var ret = _aplic.Cadastrar(dto);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Logar")]
        [HttpPost]
        public IActionResult Logar([FromBody] LoginDto dto)
        {
            try
            {
                var ret = _aplic.Logar(dto.Email, dto.Senha);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
