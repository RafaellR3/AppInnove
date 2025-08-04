using Aplicacao.Carrinhos.View;
using Aplicacao.Infra;

namespace Aplicacao.Carrinhos
{
    public interface IAplicCarrinho: IAplicBase
    {
        List<CarrinhoView> Recuperar();
    }
}
