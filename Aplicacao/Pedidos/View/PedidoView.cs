using Dominio.Pedidos;

namespace Aplicacao.Pedidos.View
{
    public class PedidoView
    {
        public Guid Id { get; set; }
        public string CodigoErp { get; set; }
        public Guid CodigoUsuario { get; set; }
        public EnumStatusPedido Status { get; set; }
        public decimal Total { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string? Bairro { get; set; }
        public string Complemento { get; set; }
        public string? NumeroEndereco { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public List<PedidoItemView> Itens { get; set; }

        public static List<PedidoView> Novo(List<Pedido> itens)
        {
            var lista = new List<PedidoView>();
            itens.ForEach(p => lista.Add(Novo(p)));
            return lista;

        }

        public static PedidoView Novo(Pedido pedido)
        {
            return new PedidoView
            {
                Id = pedido.Id,
                CodigoErp = pedido.CodigoErp,
                CodigoUsuario = pedido.CodigoUsuario,
                Status = pedido.Status,   
                Total = pedido.Total,
                NumeroEndereco = pedido.NumeroEndereco,
                Complemento = pedido.Complemento,
                Bairro = pedido.Bairro,
                Cidade = pedido.Cidade,
                Rua = pedido.Rua,
                DataAtualizacao = pedido.DataAtualizacao,
                DataCriacao = pedido.DataCriacao,
                Itens = PedidoItemView.Novo(pedido.Itens)
            };
        }
    }
}
