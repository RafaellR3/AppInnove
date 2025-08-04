using Aplicacao.Produtos.View;
using Dominio.Carrinhos.Itens;

namespace Aplicacao.Carrinhos.View
{
    public  class CarrinhoItemView
    {
        public Guid Id { get; set; }
        public Guid CodigoCarrinho { get; set; }
        public Guid CodigoProduto { get; set; }
        public int Quant { get; set; } 
        public decimal PrecoUn { get; set; } 
        public DateTime DataCriacao { get; set; }

        public ProdutoView Produto { get; set; }

        public static List<CarrinhoItemView> Novo (List<CarrinhoItem> itens)
        {
            var lista = new List<CarrinhoItemView> ();
            itens.ForEach(p => lista.Add(Novo(p)));
            return lista;
        }
        public static CarrinhoItemView Novo(CarrinhoItem item)
        {
            return new CarrinhoItemView
            {
                Id = item.Id,
                CodigoCarrinho = item.CodigoCarrinho,
                CodigoProduto = item.CodigoProduto,
                Quant = item.Quant,
                PrecoUn = item.PrecoUn,
                DataCriacao = item.DataCriacao
            };
        }
    }
}
