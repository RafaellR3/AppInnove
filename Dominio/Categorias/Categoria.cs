using Dominio.Infra;

namespace Dominio.Categorias
{
    public class Categoria: IdentificadorGuid
    {
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
    }
}
