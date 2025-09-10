using Aplicacao.Enderecos.View;
using Dominio.Enderecos;
using Dominio.Enderecos.Dto;

namespace Aplicacao.Enderecos
{
    public class AplicEnderecoUsuario: IAplicEnderecoUsuario
    {
        private readonly IRepEnderecoUsuario _repEnderecoUsuario;
        public AplicEnderecoUsuario(IRepEnderecoUsuario repEnderecoUsuario)
        {
            _repEnderecoUsuario = repEnderecoUsuario;
        }

        public List<EnderecoUsuarioView> Recuperar()
        {
            var query = _repEnderecoUsuario.Recuperar();
            return EnderecoUsuarioView.Novo(query.ToList());
        }

        public List<EnderecoUsuarioView> RecuperarPorUsuario(Guid codigoUsuario)
        {
            var query = _repEnderecoUsuario.Where(p => p.CodigoUsuario == codigoUsuario);
            return EnderecoUsuarioView.Novo(query.ToList());
        }

        public EnderecoUsuarioView Novo(EnderecoUsuarioDto dto)
        {
            var endereco = new EnderecoUsuario
            {
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                CodigoUsuario = dto.CodigoUsuario,
                Complemento = dto.Complemento,
                Numero = dto.Numero,
                Rua = dto.Rua,
                Padrao = dto.Padrao
            };

            if (dto.Padrao)
            {
                var enderecosUsuario = _repEnderecoUsuario.Where(p => p.CodigoUsuario == dto.CodigoUsuario).ToList();
                enderecosUsuario.ForEach(p => p.Padrao = false);
            }

            _repEnderecoUsuario.InserirPersistido(endereco);

            return EnderecoUsuarioView.Novo(endereco);
        }

        public EnderecoUsuarioView DefinirComoPadrao(Guid codigoUsuario, Guid codigoEndereco) 
        {
            var enderecosUsuario = _repEnderecoUsuario.Where(p => p.CodigoUsuario == codigoUsuario).ToList();
            var enderecoPadrao = enderecosUsuario.FirstOrDefault(p => p.Id == codigoEndereco);
            if (enderecoPadrao is null)
                throw new Exception($"Endereço de código {codigoEndereco} não encontrato.");
            enderecosUsuario.ForEach(p => p.Padrao = false);
            enderecoPadrao.Padrao = true;

            _repEnderecoUsuario.Persistir();
            return EnderecoUsuarioView.Novo(enderecoPadrao);
        } 
    }
}
