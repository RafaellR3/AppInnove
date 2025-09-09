using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Pedidos
{
    public class PedidoDto
    {
        public Guid CodigoUsuario { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string? Bairro { get; set; }
        public string Complemento { get; set; }
        public string? Numero { get; set; }
        public decimal Total { get; set; }

        public List<PedidoItemDto> Itens { get; set; }
    }

    public class PedidoItemDto
    {
        public Guid CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUn { get; set; }
    }

}
