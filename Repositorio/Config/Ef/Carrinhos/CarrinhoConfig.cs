using Dominio.Carrinhos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config.Ef.Carrinhos
{
    public class CarrinhoConfig : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.ToTable("carrinho");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(c => c.CodigoUsuario)
                .HasColumnName("usuario_id")
                .IsRequired();

            builder.Property(c => c.DataCriacao)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(c => c.DataAtualizacao)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.CodigoUsuario);
        }
    }
}
