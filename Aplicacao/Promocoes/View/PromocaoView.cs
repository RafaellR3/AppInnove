using Aplicacao.Produtos.View;
using Dominio.Promocoes;

namespace Aplicacao.Promocoes.View
{
    public class PromocaoView
    {
        public Guid Id { get; set; }
        public Guid CodigoProduto { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorPromocao { get; set; }
        public bool Ativo { get; set; }

        public ProdutoView Produto { get; set; }

        public static List<PromocaoView> Novo(List<Promocao> promocoes)
        {
            var list = new List<PromocaoView>();
            promocoes.ForEach(p => list.Add(Novo(p)));
            return list;
        }

        public static PromocaoView Novo(Promocao promocao)
        {
            return new PromocaoView
            {
                Id = promocao.Id,
                CodigoProduto = promocao.CodigoProduto,
                ValorOriginal = promocao.ValorOriginal,
                ValorPromocao = promocao.ValorPromocao,
                Ativo = promocao.Ativo,
                Produto = ProdutoView.Novo(promocao.Produto)
            };
        }
    }
}
