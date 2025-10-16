namespace Aplicacao.Usuarios.Dto
{
    public class CadastrarUsuarioDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Senha { get; set; }
        public int Cpf { get; set; }
    }
}
