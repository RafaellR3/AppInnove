using Dominio.Infra;
using Dominio.Produtos;

namespace Dominio.Promocoes
{
    public class Promocao : IdentificadorGuid
    {
        public Guid CodigoProduto { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorPromocao { get; set; }
        public bool Ativo { get; set; }

        public virtual Produto Produto { get; set; }
    }

}
