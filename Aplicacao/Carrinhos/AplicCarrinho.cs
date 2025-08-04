using Aplicacao.Carrinhos.View;
using Aplicacao.Produtos.View;
using Aplicacao.Usuarios.View;
using Dominio.Carrinhos;
using Dominio.Carrinhos.Itens;
using Dominio.Produtos;

namespace Aplicacao.Carrinhos
{
    public class AplicCarrinho : IAplicCarrinho
    {
        private IRepCarrinho _repCarrinho;
        public AplicCarrinho(IRepCarrinho repCarrinho)
        {
            _repCarrinho = repCarrinho;
        }

        public List<CarrinhoView> Recuperar()
        {
            var query = _repCarrinho.Recuperar();
            return [.. query.Select(p => new CarrinhoView
            {
                Id = p.Id,
                CodigoUsuario = p.CodigoUsuario,
                DataCriacao = p.DataCriacao,
                DataAtualizacao = p.DataAtualizacao,
                Usuario = UsuarioView.Novo(p.Usuario),
                Itens = CarrinhoItemView.Novo(p.Itens)    
            })];
        }
    }
}
