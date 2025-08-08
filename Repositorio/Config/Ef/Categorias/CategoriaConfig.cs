using Dominio.Categorias;
using Dominio.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config.Ef.Categorias
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(p => p.Nome)
               .HasColumnName("nome")
               .HasColumnType("text");

            builder.Property(p => p.UrlImagem)
                .HasColumnName("urlimagem")
                .HasColumnType("text");

        }
    }
}
