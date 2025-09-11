using Dominio.Promocoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config.Ef.Promocoes
{
    public class PromocaoConfig : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.ToTable("promocao");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("idpromocao")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(p => p.CodigoProduto)
                .HasColumnName("idproduto")
                .IsRequired();

            builder.Property(p => p.ValorOriginal)
                .HasColumnName("valororiginal")
                .IsRequired();

            builder.Property(p => p.ValorPromocao)
                .HasColumnName("valorpromocao")
                .IsRequired();
            builder.Property(u => u.Ativo)
                .HasColumnName("ativo")
                .HasDefaultValue(true);

            builder.HasOne(u => u.Produto)
                .WithMany()
                .HasForeignKey(u => u.CodigoProduto);
        }
    }
}