using Aplicacao.Enderecos.View;
using Dominio.Enderecos.Dto;

namespace Aplicacao.Enderecos
{
    public interface IAplicEnderecoUsuario
    {
        List<EnderecoUsuarioView> Recuperar();
        List<EnderecoUsuarioView> RecuperarPorUsuario(Guid codigoUsuario);
        void Novo(EnderecoUsuarioDto dto);
        void DefinirComoPadrao(Guid codigoUsuario, Guid codigoEndereco);
    }
}
