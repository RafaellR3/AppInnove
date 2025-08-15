namespace Aplicacao.Carrinhos.View
{
    public class CarrinhoCompraItemView
    {
        public Guid CodigoCarrinhoItem { get; set; }
        public decimal Preco { get; set; }
        public decimal ValorTotal { get; set; }
        public int Quantidade { get; set; }
        public Guid CodigoProduto { get; set; }
        public string? ProdutoNome { get; set; }
        public string UrlImagem { get; set; }
    }
}
