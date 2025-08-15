using Dominio.Carrinhos.Itens;
using Dominio.Infra;
using Dominio.Usuarios;

namespace Dominio.Carrinhos
{
    public class Carrinho: IdentificadorGuid
    {
        public Guid CodigoUsuario { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public decimal  ValorTotal { get; set; } = 0;

        public virtual Usuario Usuario { get; set; }
        public virtual List<CarrinhoItem> Itens { get; set; } = [];
    }
}
