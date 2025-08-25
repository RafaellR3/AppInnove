using Dominio.Pedidos;
using Repositorio.Infra;

namespace Repositorio.Pedidos
{
    public class RepPedido : RepBase<Pedido>, IRepPedido
    {
        public RepPedido(Contexto contexto) : base(contexto)
        {

        }
    }
}
