using Aplicacao.Carrinhos.Dto;
using Aplicacao.Carrinhos.View;
using Aplicacao.Infra;

namespace Aplicacao.Carrinhos
{
    public interface IAplicCarrinho: IAplicBase
    {
        List<CarrinhoView> Recuperar();
        CarrinhoView RecuperarPorUsuario(Guid codigoUsuario);
        CarrinhoView AdicionarItem(AdicionarItemCarrinhoDto dto);
        CarrinhoView AlterarQuantidadeItem(AlterarQuantItemCarrinhoDto dto);
        List<CarrinhoCompraItemView> RecuperarCarrinhoItensPorUsuario(Guid codigoUsuario);
        CarrinhoView RemoverItem(Guid codigo);
    }
}
