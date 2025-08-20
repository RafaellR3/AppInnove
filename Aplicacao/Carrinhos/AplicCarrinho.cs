using Aplicacao.Carrinhos.Dto;
using Aplicacao.Carrinhos.View;
using Aplicacao.Usuarios.View;
using Dominio.Carrinhos;
using Dominio.Carrinhos.Itens;
using Dominio.Produtos;
using Dominio.Usuarios;
using System.Data;

namespace Aplicacao.Carrinhos
{
    public class AplicCarrinho : IAplicCarrinho
    {
        private readonly IRepCarrinho _repCarrinho;
        private readonly IRepProduto _repProduto;
        private readonly IRepCarrinhoItem _repCarrinhoItem;
        private readonly IRepUsuario _repUsuario;
        public AplicCarrinho(IRepCarrinho repCarrinho,
                             IRepProduto repProduto,
                             IRepCarrinhoItem repCarrinhoItem,
                             IRepUsuario repUsuario)
        {
            _repCarrinho = repCarrinho;
            _repProduto = repProduto;
            _repCarrinhoItem = repCarrinhoItem;
            _repUsuario = repUsuario;
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

        private Carrinho Novo(Guid codigoUsuario)
        {
            var carrinho = _repCarrinho.FirstOrDefault(p => p.CodigoUsuario == codigoUsuario);
            if (carrinho != null)
                return carrinho;

            carrinho = new Carrinho()
            {
                Id = Guid.NewGuid(),
                CodigoUsuario = codigoUsuario,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now,
                Itens = [],
                Usuario = _repUsuario.FirstOrDefault(P => P.Id == codigoUsuario)
            };

            _repCarrinho.InserirPersistido(carrinho);
            return carrinho;
        }

        public CarrinhoView RecuperarPorUsuario(Guid codigoUsuario)
        {
            var usuario = _repUsuario.FirstOrDefault(p => p.Id == codigoUsuario);
            if (usuario == null)
                throw new Exception($"Usuário de código {codigoUsuario} não localizado.");

            var carrinho = _repCarrinho.FirstOrDefault(p => p.CodigoUsuario == codigoUsuario);
            if (carrinho == null)
            {
                carrinho = new Carrinho
                {
                    CodigoUsuario = usuario.Id,
                    Usuario = usuario
                };
                _repCarrinho.InserirPersistido(carrinho);
                _repCarrinho.Persistir();
            }
            return CarrinhoView.Novo(carrinho);
        }

        public List<CarrinhoCompraItemView> RecuperarCarrinhoItensPorUsuario(Guid codigoUsuario)
        {
            var usuario = _repUsuario.FirstOrDefault(p => p.Id == codigoUsuario);
            if (usuario == null)
                throw new Exception($"Usuário de código {codigoUsuario} não localizado.");

            var lista = new List<CarrinhoCompraItemView>();
            var carrinho = _repCarrinho.FirstOrDefault(p => p.CodigoUsuario == codigoUsuario);
            if (carrinho == null)
                return lista;

            return carrinho.Itens.Select(p => new CarrinhoCompraItemView
            {
                CodigoCarrinhoItem = p.Id,
                CodigoProduto = p.CodigoProduto,
                Preco = p.PrecoUn,
                ProdutoNome = p.Produto.Nome,
                Quantidade = p.Quant,
                UrlImagem = p.Produto.UrlImagem,
                ValorTotal = p.ValorTotal
            }).ToList();
        }

        public CarrinhoView AdicionarItem(AdicionarItemCarrinhoDto dto)
        {
            var usuario = _repUsuario.FirstOrDefault(p => p.Id == dto.CodigoUsuario);
            var carrinho = _repCarrinho.FirstOrDefault(p => p.CodigoUsuario == dto.CodigoUsuario);
            if (carrinho == null)
                carrinho = Novo(usuario.Id);

            var produto = _repProduto.FirstOrDefault(p => p.Id == dto.CodigoProduto);
            if (produto == null)
                throw new Exception($"Produto de código {dto.CodigoProduto} não localizado.");

            var itemExistente = carrinho.Itens.FirstOrDefault(p => p.CodigoProduto == dto.CodigoProduto);
            if (itemExistente != null)
            {
                itemExistente.Quant += dto.Quant;
                itemExistente.ValorTotal = itemExistente.PrecoUn * itemExistente.Quant;
            }
            else
            {

                var carrinhoItem = new CarrinhoItem
                {
                    CodigoCarrinho = carrinho.Id,
                    CodigoProduto = dto.CodigoProduto,
                    Quant = dto.Quant,
                    PrecoUn = produto.Preco,
                    Carrinho = carrinho,
                    Produto = produto,
                    ValorTotal = dto.ValorTotal,

                };

                carrinho.Itens.Add(carrinhoItem);
            }

            _repCarrinhoItem.Persistir();

            carrinho.Totalizar();
            _repCarrinho.Persistir();

            return CarrinhoView.Novo(carrinho);
        }

        public CarrinhoView AlterarQuantidadeItem(AlterarQuantItemCarrinhoDto dto)
        {
            var carrinhoItem = _repCarrinhoItem.FirstOrDefault(p => p.Id == dto.CodigoCarrinhoItem);
            if (carrinhoItem == null)
                throw new Exception($"Carrinho item de código {dto.CodigoCarrinhoItem} não localizado.");

            carrinhoItem.Quant = dto.Quant;

            _repCarrinhoItem.Persistir();

            carrinhoItem.Carrinho.Totalizar();
            _repCarrinho.Persistir();

            return CarrinhoView.Novo(carrinhoItem.Carrinho);
        }

        public CarrinhoView RemoverItem(RemoverItemCarrinhoDto dto)
        {
            var carrinho = _repCarrinho.FirstOrDefault(p => p.Id == dto.CodigoCarrinho);
            if (carrinho == null)
                throw new Exception($"Carrinho não localizado.");

            var item = carrinho.Itens.FirstOrDefault(p => p.CodigoProduto == dto.CodigoProduto);

            _repCarrinhoItem.Remover(item);

            _repCarrinhoItem.Persistir();

            carrinho.Totalizar();

            _repCarrinho.Persistir();

            return CarrinhoView.Novo(carrinho);
        }
    }
}
