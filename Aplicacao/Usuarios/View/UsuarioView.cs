namespace Aplicacao.Usuarios.View
{
    public class UsuarioView
    {
        public string CodigoERP { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; } 
        public string SenhaHash { get; set; } 
        public bool Ativo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
    }
}
