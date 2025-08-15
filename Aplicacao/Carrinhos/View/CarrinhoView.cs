using Aplicacao.Usuarios.View;
using Dominio.Carrinhos;
using Dominio.Carrinhos.Itens;

namespace Aplicacao.Carrinhos.View
{
    public class CarrinhoView
    {
        public Guid Id { get; set; }
        public Guid CodigoUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public decimal ValorTotal { get; set; }

        public UsuarioView Usuario { get; set; }
        public List<CarrinhoItemView> Itens { get; set; } = [];

        public static List<CarrinhoView> Novo(List<Carrinho> carrinhos)
        {
            var lista = new List<CarrinhoView>();
            carrinhos.ForEach(p => lista.Add(Novo(p)));
            return lista;
        }

        public static CarrinhoView Novo(Carrinho carrinho)
        {
            return new CarrinhoView
            {
                Id = carrinho.Id,
                CodigoUsuario = carrinho.CodigoUsuario,
                DataAtualizacao = carrinho.DataAtualizacao,
                DataCriacao = carrinho.DataCriacao,
                Usuario = UsuarioView.Novo(carrinho.Usuario),
                Itens = CarrinhoItemView.Novo(carrinho.Itens)
            };
        }
    }
}
