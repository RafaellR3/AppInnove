using Dominio.Enderecos;
using Repositorio.Infra;

namespace Repositorio.Enderecos
{
    public class RepEnderecoUsuario : RepBase<EnderecoUsuario>, IRepEnderecoUsuario
    {
        public RepEnderecoUsuario(Contexto contexto) : base(contexto)
        {

        }
    }
}
