using Aplicacao.Infra;
using Aplicacao.Pedidos.View;

namespace Aplicacao.Pedidos
{
    public interface IAplicPedido : IAplicBase
    {
        List<PedidoView> Recuperar();
        PedidoView PesquisarPorId(Guid id);
        void Novo(PedidoDto dto);
    }
}

