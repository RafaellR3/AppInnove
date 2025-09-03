using Aplicacao.Infra;
using Aplicacao.Pedidos.View;
using Dominio.Pedidos;

namespace Aplicacao.Pedidos
{
    public interface IAplicPedido : IAplicBase
    {
        List<PedidoView> Recuperar();
        PedidoView PesquisarPorId(Guid id);
        void Novo(PedidoDto dto);
        List<ListaPedidoView> PedidosEmAbertoPorUsuario(Guid codigoUsuario);
        List<ListaPedidoView> PedidosFinalizadosPorUsuario(Guid codigoUsuario);
        List<ListaPedidoView> PedidosPorUsuario(Guid codigoUsuario);
    }
}

