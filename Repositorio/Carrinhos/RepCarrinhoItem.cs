using Dominio.Carrinhos.Itens;
using Repositorio.Infra;

namespace Repositorio.Carrinhos
{
    public class RepCarrinhoItem: RepBase<CarrinhoItem>, IRepCarrinhoItem
    {
        public RepCarrinhoItem(Contexto contexto): base(contexto)
        {            
        }
    }
}
