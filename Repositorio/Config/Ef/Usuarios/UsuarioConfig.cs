using Dominio.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Config.Ef.Usuarios
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(u => u.CodigoERP)
                .HasColumnName("id_erp")
                .HasColumnType("text");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("text");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("text");

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.SenhaHash)
                .IsRequired()
                .HasColumnName("senha_hash")
                .HasColumnType("text");

            builder.Property(u => u.Ativo)
                .HasColumnName("ativo")
                .HasDefaultValue(true);

            builder.Property(u => u.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("NOW()");

            builder.Property(u => u.UpdatedAt)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("NOW()");
        
        }
    }
}
