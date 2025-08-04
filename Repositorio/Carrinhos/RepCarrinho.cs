using Dominio.Carrinhos;
using Repositorio.Infra;

namespace Repositorio.Carrinhos
{
    public class RepCarrinho: RepBase<Carrinho>, IRepCarrinho
    {
        public RepCarrinho(Contexto contexto): base(contexto)
        {            
        }
    }
}
