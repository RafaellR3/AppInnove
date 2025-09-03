using Dominio.Pedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config.Ef.Pedidos
{
    public class PedidoItemConfig : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("item_pedido");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(p => p.CodigoPedido)
               .HasColumnName("pedido_id")
               .IsRequired();

            builder.Property(p => p.CodigoProduto)
                .HasColumnName("produto_id")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(p => p.PrecoUn)
                .HasColumnName("preco_unitario")
                .HasColumnType("numeric(12, 2)")
                .IsRequired();

            builder.Property(p => p.DataCriacao)
                .HasColumnName("criado_em")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasOne(p => p.Pedido)
                .WithMany(y => y.Itens)
                .HasForeignKey(p => p.CodigoPedido);
        }
    }
}
