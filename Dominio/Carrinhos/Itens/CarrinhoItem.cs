using Dominio.Infra;
using Dominio.Produtos;

namespace Dominio.Carrinhos.Itens
{
    public class CarrinhoItem : IdentificadorGuid
    {
        public Guid CodigoCarrinho { get; set; }
        public Guid CodigoProduto { get; set; }
        public int Quant { get; set; } = 0;
        public decimal PrecoUn { get; set; } = 0;
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public virtual Carrinho Carrinho { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
