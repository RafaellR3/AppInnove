using Dominio.Categorias;
using Dominio.Infra;

namespace Dominio.Produtos
{
    public class Produto: IdentificadorGuid
    {
        public string CodigoERP { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; } = 0;
        public int Estoque { get; set; } = 0;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
        public string Imagem { get; set; }
        public bool Ativo { get; set; } = true;
        public Guid? CodigoCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
