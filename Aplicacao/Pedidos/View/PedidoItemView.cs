using Aplicacao.Produtos.View;
using Dominio.Infra;

namespace Dominio.Pedidos
{
    public class PedidoItemView 
    {
        public Guid Id { get; set; }
        public Guid CodigoPedido { get; set; }
        public Guid CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUn { get; set; }
        public DateTime DataCriacao { get; set; }

        public ProdutoView Produto { get; set; }

        public static List<PedidoItemView> Novo(List<PedidoItem> itens)
        {
            var lista = new List<PedidoItemView>();
            itens.ForEach(p => lista.Add(Novo(p)));
            return lista;

        }
        public static PedidoItemView Novo(PedidoItem item)
        {
            return new PedidoItemView
            {
                Id = item.Id,
                CodigoPedido = item.CodigoPedido,
                CodigoProduto = item.CodigoProduto,
                Quantidade = item.Quantidade,
                PrecoUn = item.PrecoUn, 
                DataCriacao = item.DataCriacao,
                Produto = ProdutoView.Novo(item.Produto)
            };
        }
    }
}
