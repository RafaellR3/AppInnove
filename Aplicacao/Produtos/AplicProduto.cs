using Aplicacao.Produtos.View;
using Dominio.Pedidos;
using Dominio.Produtos;

namespace Aplicacao.Produtos
{
    public class AplicProduto: IAplicProduto
    {
        private readonly IRepProduto _repProduto;
        private readonly IRepPedidoItem _repPedidoItem;
        public AplicProduto(IRepProduto repProduto)
        {
            _repProduto = repProduto;
        }

        public List<ProdutoView> Recuperar()
        {
            var query = _repProduto.Recuperar();
            return ProdutoView.Novo(query.ToList());
        }

        public List<ProdutoView> Pesquisar(string pesquisa)
        {
            var query = _repProduto.Where(p => p.Descricao.ToUpper().Contains(pesquisa.ToUpper()) ||
                                               p.CodigoERP.ToUpper().Contains(pesquisa.ToUpper()) ||
                                               p.Nome.ToUpper().Contains(pesquisa.ToUpper()));
            return [.. query.Select(p => new ProdutoView
            {
                Id = p.Id,
                CodigoERP = p.CodigoERP,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Estoque = p.Estoque,
                CreatedAt = p.DataCriacao,
                UpdatedAt = p.DataAtualizacao,
                Imagem = p.Imagem,
                Ativo = p.Ativo,
                CodigoCategoria = p.CodigoCategoria.Value
            })];
        }

        public ProdutoView PesquisarPorId(Guid id)
        {
            var produto = _repProduto.FirstOrDefault(p => p.Id == id);
            return ProdutoView.Novo(produto);
        }

        public List<ProdutoView> PesquisarPorCategoria(Guid id)
        {
            var produtos = _repProduto.Where(p => p.CodigoCategoria == id).ToList();
            return ProdutoView.Novo(produtos);
        }

        public List<ProdutoView> RecuperarProdutosMaisVendidos()
        {
            var itens = _repPedidoItem.Recuperar().GroupBy(p => new { p.Produto}).Select(item => new
            {
                Item = item.Key.Produto,
                Quant = item.Sum(x => x.Quantidade)
            }).OrderByDescending(x => x.Quant).Take(10).ToList();

            List<Produto> produtos = itens.Select(p => p.Item).ToList();

            return ProdutoView.Novo(produtos);
        }

    }
}
