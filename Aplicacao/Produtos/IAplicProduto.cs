using Aplicacao.Infra;
using Aplicacao.Produtos.View;

namespace Aplicacao.Produtos
{
    public interface IAplicProduto: IAplicBase
    {
        List<ProdutoView> Recuperar();
    }
}
