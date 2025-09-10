using Aplicacao.Usuarios.View;
using Dominio.Enderecos;
using Dominio.Usuarios;

namespace Aplicacao.Enderecos.View
{
    public class EnderecoUsuarioView
    {
        public Guid Id { get; set; }
        public Guid CodigoUsuario { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public int Cep { get; set; }
        public bool Padrao { get; set; }

        public UsuarioView Usuario { get; set; }

        public static List<EnderecoUsuarioView> Novo(List<EnderecoUsuario> enderecoUsuarios)
        {
            var lista = new List<EnderecoUsuarioView>();
            enderecoUsuarios.ForEach(x => lista.Add(Novo(x)));  
            return lista;
        }

        public static EnderecoUsuarioView Novo(EnderecoUsuario enderecoUsuario)
        {
            return new EnderecoUsuarioView()
            {
                Id = enderecoUsuario.Id,
                Bairro = enderecoUsuario.Bairro,
                Cep = enderecoUsuario.Cep,
                Cidade = enderecoUsuario.Cidade,
                CodigoUsuario = enderecoUsuario.CodigoUsuario,
                Complemento = enderecoUsuario.Complemento,
                Numero = enderecoUsuario.Numero,
                Rua = enderecoUsuario.Rua,
                Padrao = enderecoUsuario.Padrao,
                Usuario = UsuarioView.Novo(enderecoUsuario.Usuario)
            };
        }
    }
}
