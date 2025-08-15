namespace Aplicacao.Carrinhos.Dto
{
    public class AdicionarItemCarrinhoDto
    {
        public Guid CodigoProduto { get; set; }
        public Guid CodigoUsuario { get; set; }
        public int Quant { get; set; }
        public decimal PrecoUn { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
