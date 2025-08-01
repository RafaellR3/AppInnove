using Aplicacao.Usuarios.View;
using Dominio.Usuarios;

namespace Aplicacao.Usuarios
{
    
    public class AplicUsuario: IAplicUsuario
    {
        private IRepUsuario _repUsuario;
        public AplicUsuario(IRepUsuario repUsuario)
        {
            _repUsuario = repUsuario;
        }


        public List<UsuarioView> Recuperar()
        {
            var query = _repUsuario.Recuperar();
            return query.Select(p => new UsuarioView
            {
                CodigoERP = p.CodigoERP,
                Ativo = p.Ativo,
                CreatedAt = DateTime.Now,
                Email = p.Email,
                Nome = p.Nome,
                SenhaHash = p.SenhaHash,
                UpdatedAt = DateTime.Now
            }).ToList();

        }
    }

   
}
