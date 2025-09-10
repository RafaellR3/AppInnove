using Dominio.Infra;
using Dominio.Usuarios;

namespace Dominio.Enderecos
{
    public class EnderecoUsuario: IdentificadorGuid
    {
        public Guid CodigoUsuario { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public int Cep { get; set; }
        public bool Padrao { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}
