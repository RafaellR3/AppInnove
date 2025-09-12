using Aplicacao.Promocoes.View;
using Dominio.Promocoes;

namespace Aplicacao.Promocoes
{
    public class AplicPromocao : IAplicPromocao
    {
        private readonly IRepPromocao _repPromocao;
        public AplicPromocao(IRepPromocao repPromocao)
        {
            _repPromocao = repPromocao;
        }

        public List<PromocaoView> Recuperar()
        {
            var query = _repPromocao.Where(p => p.Ativo).ToList();
            return PromocaoView.Novo(query);
        }

    }
}
