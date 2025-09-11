using Dominio.Promocoes;
using Repositorio.Infra;

namespace Repositorio.Promocoes
{
    public class RepPromocao : RepBase<Promocao>, IRepPromocao
    {
        public RepPromocao(Contexto contexto) : base(contexto)
        {

        }

    }
}
