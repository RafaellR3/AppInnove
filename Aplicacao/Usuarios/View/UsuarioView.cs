using Dominio.Usuarios;

namespace Aplicacao.Usuarios.View
{
    public class UsuarioView
    {
        public Guid Id { get; set; }
        public string CodigoERP { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; } 
        public string SenhaHash { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Cpf { get; set; }

        public static List<UsuarioView> Novo(List<Usuario> usuarios)
        {
            var lista = new List<UsuarioView>();
            usuarios.ForEach(p => lista.Add(Novo(p)));
            return lista;
        }
        public static UsuarioView Novo(Usuario usuario)
        {
            return new UsuarioView
            {
                Id = usuario.Id,
                CodigoERP = usuario.CodigoERP,
                Ativo = usuario.Ativo,
                CreatedAt = usuario.CreatedAt,
                Email = usuario.Email,
                Nome = usuario.Nome,
                SenhaHash = usuario.SenhaHash,
                UpdatedAt = usuario.UpdatedAt,
                Telefone = usuario.Telefone,
                Cpf =  usuario.Cpf                
            };
        }
    }
}
