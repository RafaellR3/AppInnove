using Dominio.Produtos;
using Repositorio.Infra;

namespace Repositorio.Produtos
{
    public class RepProduto: RepBase<Produto>, IRepProduto
    {
        public RepProduto(Contexto contexto): base(contexto)
        {
            
        }

    }
}
