using Dominio.Infra;

namespace Dominio.Pedidos
{
    public class PedidoItem : IdentificadorGuid
    {
        public Guid CodigoPedido { get; set; }
        public Guid CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUn { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public virtual Pedido Pedido { get; set; }
    }
}
