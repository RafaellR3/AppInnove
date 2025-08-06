namespace Aplicacao.Carrinhos.Dto
{
    public class AdicionarItemCarrinhoDto
    {
        public Guid CodigoCarrinho { get; set; }
        public Guid CodigoProduto { get; set; }
        public int Quant { get; set; }
    }
}
