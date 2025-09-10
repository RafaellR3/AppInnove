using Dominio.Enderecos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config.Ef.Enderecos
{
    public class EnderecoUsuarioConfig : IEntityTypeConfiguration<EnderecoUsuario>
    {
        public void Configure(EntityTypeBuilder<EnderecoUsuario> builder)
        {
            builder.ToTable("endereco_usuario");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("idendereco")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(p => p.CodigoUsuario)
               .HasColumnName("idusuario")
               .IsRequired();

            builder.Property(p => p.Rua)
               .HasColumnName("rua")
               .HasColumnType("text");

            builder.Property(p => p.Cidade)
               .HasColumnName("cidade")
               .HasColumnType("text");

            builder.Property(p => p.Bairro)
               .HasColumnName("bairro")
               .HasColumnType("text");

            builder.Property(p => p.Complemento)
               .HasColumnName("complemento")
               .HasColumnType("text");

            builder.Property(p => p.Numero)
               .HasColumnName("numero")
               .HasColumnType("text");

            builder.Property(p => p.Cep)
               .HasColumnName("cep");

            builder.Property(p => p.Padrao)
               .HasColumnName("padrao")
               .IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.CodigoUsuario);
        }
    }
}
