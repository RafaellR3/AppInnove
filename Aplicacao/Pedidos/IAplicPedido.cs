using Aplicacao.Infra;
using Aplicacao.Pedidos.View;

namespace Aplicacao.Pedidos
{
    public interface IAplicPedido : IAplicBase
    {
        List<PedidoView> Recuperar();
        PedidoView PesquisarPorId(Guid id);
        PedidoView Novo(PedidoDto dto);
        List<ListaPedidoView> PedidosEmAbertoPorUsuario(Guid codigoUsuario);
        List<ListaPedidoView> PedidosEmAberto();
        List<ListaPedidoView> PedidosFinalizadosPorUsuario(Guid codigoUsuario);
        List<ListaPedidoView> PedidosFinalizados();
        List<ListaPedidoView> PedidosPorUsuario(Guid codigoUsuario);
        void Confirmar(Guid id); 
        void Cancelar(Guid id);
        void Recusar(Guid id); 
        void Enviar(Guid id);
        void Entregar(Guid id);
        void Finalizar(Guid id);
    }
}

