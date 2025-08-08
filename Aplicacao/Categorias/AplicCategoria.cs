using Aplicacao.Categorias.View;
using Dominio.Categorias;

namespace Aplicacao.Categorias
{
    public class AplicCategoria: IAplicCategoria
    {
        private readonly IRepCategoria _repCategoria;
        public AplicCategoria(IRepCategoria repCategoria)
        {
            _repCategoria = repCategoria;
        }

        public List<CategoriaView> Recuperar()
        {
            var query = _repCategoria.Recuperar();
            return CategoriaView.Novo([.. query]);
        }
    }
}
