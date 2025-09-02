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
        List<PedidoView> PedidosEmAbertoPorUsuario(Guid codigoUsuario);
        List<PedidoView> PedidosFinalizadosPorUsuario(Guid codigoUsuario);
    }
}

