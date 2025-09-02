using Dominio.Infra;
using System.ComponentModel;

namespace Dominio.Pedidos
{
    public class Pedido : IdentificadorGuid
    {
        public Pedido()
        {
            
        }
        public string CodigoErp { get; set; }
        public Guid CodigoUsuario { get; set; }
        public decimal Total { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string? Bairro { get; set; }
        public string Complemento { get; set; }
        public string? NumeroEndereco { get; set; }
        public EnumStatusPedido Status { get; set; } = EnumStatusPedido.Criado;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;

        public virtual List<PedidoItem> Itens { get; set; } = [];

        public static List<EnumStatusPedido> StatusEmAberto = [EnumStatusPedido.Enviado, EnumStatusPedido.Criado, EnumStatusPedido.Confirmado];
    }

    public enum EnumStatusPedido
    {
        [Description("Criado")]
        Criado = 0,
        [Description("Confirmado")]
        Confirmado = 1,
        [Description("Enviado")]
        Enviado = 2,
        [Description("Entregue")]
        Entregue = 3,
        [Description("Cancelado")]
        Cancelado = 4,
        [Description("Recusado")]
        Recusado = 5
    }
}
