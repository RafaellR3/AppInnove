using Dominio.Carrinhos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dominio.Carrinhos.Itens;

namespace Repositorio.Config.Ef.Carrinhos
{

    public class ItemCarrinhoConfig : IEntityTypeConfiguration<CarrinhoItem>
    {
        public void Configure(EntityTypeBuilder<CarrinhoItem> builder)
        {
            builder.ToTable("item_carrinho");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(i => i.CodigoCarrinho)
                .HasColumnName("carrinho_id")
                .IsRequired();

            builder.Property(i => i.CodigoProduto)
                .HasColumnName("produto_id")
                .IsRequired();

            builder.Property(i => i.Quant)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(i => i.PrecoUn)
                .HasColumnName("preco_unitario")
                .HasColumnType("numeric(12, 2)")
                .IsRequired();

            builder.Property(i => i.ValorTotal)
                .HasColumnName("valortotal")
                .HasColumnType("numeric(12, 2)")
                .IsRequired();

            builder.Property(i => i.DataCriacao)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .IsRequired();

            // Relacionamentos
            builder.HasOne(i => i.Carrinho)
                .WithMany(c => c.Itens)
                .HasForeignKey(i => i.CodigoCarrinho)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Produto)
                .WithMany()
                .HasForeignKey(i => i.CodigoProduto)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
