using Dominio.Pedidos;

namespace Aplicacao.Pedidos.View
{
    public class ListaPedidoView
    {
        public string  Numero { get; set; }
        public DateTime Data { get; set; }
        public int Quant { get; set; }
        public decimal Total { get; set; }
        public EnumStatusPedido  Status { get; set; }

        public List<PedidoItemView> Itens { get; set; }
    }
}
