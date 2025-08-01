namespace Dominio.Infra
{
    public class IdentificadorGuid
    {
        public IdentificadorGuid()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
