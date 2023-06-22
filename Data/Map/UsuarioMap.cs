using CarZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Tabela
            builder.ToTable("Usuarios");

            // Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Nome)
                           .IsRequired()
                           .HasColumnName("Nome")
                           .HasColumnType("NVARCHAR")
                           .HasMaxLength(50);

            builder.Property(x => x.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);


            builder.Property(x => x.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(255);

            builder.Property(x => x.Senha)
                    .IsRequired()
                    .HasColumnName("Senha")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(128);

            builder.Property(x => x.Perfil)
                    .IsRequired()
                    .HasColumnName("Perfil")
                    .HasColumnType("INT")
                    .HasMaxLength(2);

            builder.Property(x => x.DataCadastro)
                    .IsRequired()
                    .HasColumnName("DataCadastro")
                    .HasColumnType("datetime")
                    .HasMaxLength(10);

            builder.Property(x => x.DataAtualizacao)
                    .HasColumnName("DataAtualizacao")
                    .HasColumnType("datetime")
                    .HasMaxLength(10);

        }
    }
}
