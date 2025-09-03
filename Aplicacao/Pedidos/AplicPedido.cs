using Aplicacao.Pedidos.View;
using Dominio.Pedidos;

namespace Aplicacao.Pedidos
{
    public class AplicPedido: IAplicPedido
    {
        private readonly IRepPedido _repPedido;
        public AplicPedido(IRepPedido repPedido)
        {
            _repPedido = repPedido;
        }

        public List<PedidoView> Recuperar()
        {
            var query = _repPedido.Recuperar();
            return PedidoView.Novo(query.ToList());
        }

        public List<ListaPedidoView> PedidosEmAbertoPorUsuario(Guid codigoUsuario)
        {            
            var pedidos = _repPedido.Where(p => p.CodigoUsuario == codigoUsuario && Pedido.StatusEmAberto.Contains(p.Status)).ToList();
            var view = pedidos.Select(p => new ListaPedidoView
            {
                Numero = p.CodigoErp,
                Data = p.DataCriacao.Date,
                Quant = p.Itens.Count(),
                Total = p.Total,
                Status = p.Status,
                Itens = PedidoItemView.Novo(p.Itens)
            }).ToList();

            return view;
        }

        public List<ListaPedidoView> PedidosFinalizadosPorUsuario(Guid codigoUsuario)
        {

            var pedidos = _repPedido.Where(p => p.CodigoUsuario == codigoUsuario && !Pedido.StatusEmAberto.Contains(p.Status)).ToList();
            var view = pedidos.Select(p => new ListaPedidoView
            {
                Numero = p.CodigoErp,
                Data = p.DataCriacao,
                Quant = p.Itens.Count(),
                Total = p.Total,
                Status = p.Status,
                Itens = PedidoItemView.Novo(p.Itens)
            }).ToList();

            return view;
        }

        public PedidoView PesquisarPorId(Guid id)
        {
            var pedido = _repPedido.FirstOrDefault(p => p.Id == id);
            return PedidoView.Novo(pedido);
        }

        public void Novo(PedidoDto dto)
        {
            var pedido = new Pedido
            {
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                CodigoUsuario = dto.CodigoUsuario,
                Complemento = dto.Complemento,
                NumeroEndereco = dto.Numero,
                Rua = dto.Rua,
                Total = dto.Total
            };

            pedido.Itens.AddRange(dto.Itens.Select(p => new PedidoItem
            {
                CodigoPedido = pedido.Id,
                CodigoProduto = p.CodigoProduto,
                PrecoUn = p.PrecoUn,
                Quantidade = p.Quantidade,
                Pedido = pedido
            }));
            pedido.CodigoErp = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()+ DateTime.Now.Second.ToString();
            _repPedido.InserirPersistido(pedido);
        }

    }
}
