using Dominio.Usuarios;
using Repositorio.Infra;

namespace Repositorio.Usuarios
{
    public class RepUsuario: RepBase<Usuario>, IRepUsuario
    {
        public RepUsuario(Contexto contexto):base(contexto) 
        {
            
        }
    }
}
