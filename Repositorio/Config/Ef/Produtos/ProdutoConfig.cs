using Dominio.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config.Ef.Produtos
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(p => p.CodigoERP)
                .HasColumnName("codigo_erp")
                .HasColumnType("text");

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("text");

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.Property(p => p.Preco)
                .HasColumnName("preco")
                .HasColumnType("numeric(12,2)");

            builder.Property(p => p.Estoque)
                .HasColumnName("estoque");

            builder.Property(p => p.DataCriacao)
                .HasColumnName("created_at")
                .HasColumnType("timestamp");

            builder.Property(p => p.DataAtualizacao)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp");

            builder.Property(p => p.Imagem)
                .HasColumnName("imagem")
                .HasColumnType("varchar");

            builder.Property(u => u.Ativo)
                .HasColumnName("ativo")
                .HasDefaultValue(true);

            builder.Property(u => u.CodigoCategoria)
                .HasColumnName("idcategroia");

            builder.HasOne(u => u.Categoria)
                .WithMany()
                .HasForeignKey(u => u.CodigoCategoria);
        }
    }
}
