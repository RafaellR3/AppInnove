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
            return UsuarioView.Novo([.. query]);
        }

        public UsuarioView PesquisarPorId(Guid id)
        {
            var usuario = _repUsuario.FirstOrDefault(p => p.Id == id);
            return UsuarioView.Novo(usuario);
        }
        public UsuarioView Logar(string email, string senha)
        {
            var usuario = _repUsuario.FirstOrDefault(p => p.Email == email && p.SenhaHash == senha);
            if (usuario == null)
                throw new Exception("Usuario ou senha inválidos.");

            return UsuarioView.Novo(usuario);
        }
    }   
}
