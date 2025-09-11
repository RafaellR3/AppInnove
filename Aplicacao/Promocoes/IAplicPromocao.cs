using Aplicacao.Infra;
using Aplicacao.Promocoes.View;

namespace Aplicacao.Promocoes
{
    public interface IAplicPromocao : IAplicBase
    {
        List<PromocaoView> Recuperar();
    }
}
