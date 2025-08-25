using Dominio.Pedidos;
using Repositorio.Infra;

namespace Repositorio.Pedidos
{
    public class RepPedidoItem : RepBase<PedidoItem>, IRepPedidoItem
    {
        public RepPedidoItem(Contexto contexto) : base(contexto)
        {

        }
    }
}
