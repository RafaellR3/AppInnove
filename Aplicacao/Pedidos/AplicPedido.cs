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
                NumeroEndereco = dto.NumeroEndereco,
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

            _repPedido.InserirPersistido(pedido);
        }
    }
}
