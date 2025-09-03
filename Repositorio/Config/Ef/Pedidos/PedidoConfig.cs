using Dominio.Pedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config.Ef.Pedidos
{
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(p => p.CodigoErp)
               .HasColumnName("id_erp");

            builder.Property(p => p.CodigoUsuario)
                .HasColumnName("usuario_id")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(p => p.Total)
                .HasColumnName("total")
                .HasColumnType("numeric(12, 2)")
                .IsRequired();

            builder.Property(p => p.Rua)
                .HasColumnName("rua");

            builder.Property(p => p.Cidade)
                .HasColumnName("cidade");

            builder.Property(p => p.Bairro)
                .HasColumnName("bairro");

            builder.Property(p => p.Complemento)
                .HasColumnName("complemento");

            builder.Property(p => p.NumeroEndereco)
                .HasColumnName("numero");

            builder.Property(p => p.DataCriacao)
                .HasColumnName("criado_em")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(p => p.DataAtualizacao)
                .HasColumnName("atualizado_em")
                .HasColumnType("timestamp")
                .IsRequired();

        }
    }
}
