using Aplicacao.Usuarios.Dto;
using Aplicacao.Usuarios.View;

namespace Aplicacao.Usuarios
{
    public interface IAplicUsuario
    {
        List<UsuarioView> Recuperar();
        UsuarioView PesquisarPorId(Guid id);
        UsuarioView Logar(string email, string senha);
        UsuarioView Cadastrar(CadastrarUsuarioDto dto);
    }
}
