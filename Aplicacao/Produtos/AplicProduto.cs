using Aplicacao.Produtos.View;
using Dominio.Produtos;

namespace Aplicacao.Produtos
{
    public class AplicProduto: IAplicProduto
    {
        private IRepProduto _repProduto;
        public AplicProduto(IRepProduto repProduto)
        {
            _repProduto = repProduto;
        }

        public List<ProdutoView> Recuperar()
        {
            var query = _repProduto.Recuperar();
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
                Ativo = p.Ativo
            })];
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
                Ativo = p.Ativo
            })];
        }


        public ProdutoView PesquisarPorId(Guid id)
        {
            var produto = _repProduto.FirstOrDefault(p => p.Id == id);
            return ProdutoView.Novo(produto);
        }
    }
}
