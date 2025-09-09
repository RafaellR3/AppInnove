using Dominio.Produtos;

namespace Aplicacao.Produtos.View
{
    public class ProdutoView 
    {
        public Guid Id { get; set; }
        public string CodigoERP { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UrlImagem { get; set; }
        public byte[] Imagem { get; set; }
        public bool Ativo { get; set; }
        public Guid CodigoCategoria { get; set; }

        public static List<ProdutoView> Novo(List<Produto> produtos)
        {
            var list = new List<ProdutoView>();
            produtos.ForEach(p => list.Add(Novo(p)));
            return list;
        }

        public static ProdutoView Novo(Produto produto)
        {
            return new ProdutoView
            {
                Id = produto.Id,
                CodigoERP = produto.CodigoERP,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque,
                CreatedAt = produto.DataCriacao,
                UpdatedAt = produto.DataAtualizacao,
                Imagem = produto.Imagem,
                UrlImagem = produto.UrlImagem,
                Ativo = produto.Ativo,
                CodigoCategoria = produto.CodigoCategoria.Value
            };
        }
    }
}
