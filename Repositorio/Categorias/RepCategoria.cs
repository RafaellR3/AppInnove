using Dominio.Categorias;
using Repositorio.Infra;

namespace Repositorio.Categorias
{
    public class RepCategoria: RepBase<Categoria>, IRepCategoria
    {
        public RepCategoria(Contexto contexto): base(contexto)
        {
            
        }
    }
}
