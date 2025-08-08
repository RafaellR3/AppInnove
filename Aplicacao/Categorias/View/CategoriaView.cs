using Dominio.Categorias;

namespace Aplicacao.Categorias.View
{
    public  class CategoriaView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }

        public static List<CategoriaView> Novo(List<Categoria> categorias)
        {
            var lista = new List<CategoriaView>();
            categorias.ForEach(c => lista.Add(Novo(c)));;
            return lista;
        }

        public static CategoriaView Novo(Categoria categoria)
        {
            return new CategoriaView
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                UrlImagem = categoria.UrlImagem
            };
        }
    }
}
