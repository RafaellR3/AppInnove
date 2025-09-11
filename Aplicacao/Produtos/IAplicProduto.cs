using Aplicacao.Infra;
using Aplicacao.Produtos.View;

namespace Aplicacao.Produtos
{
    public interface IAplicProduto: IAplicBase
    {
        List<ProdutoView> Recuperar(); 
        List<ProdutoView> Pesquisar(string pesquisa);
        ProdutoView PesquisarPorId(Guid id); 
        List<ProdutoView> PesquisarPorCategoria(Guid id);
        List<ProdutoView> RecuperarProdutosMaisVendidos();
    }
}
