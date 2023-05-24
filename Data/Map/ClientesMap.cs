using CarZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Map
{
    public class ClientesMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Tabela
            builder.ToTable("Cliente");

            // Chave Primaria
            builder.HasKey(x => x.Id);

            // Identity
            //builder.Property(x => x.Id)
            //    .ValueGeneratedOnAdd()
            //    .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasColumnName("CPF")
                .HasColumnType("INT")
                .HasMaxLength(11);

            builder.Property(x => x.Endereco)
               .IsRequired()
               .HasColumnName("Endereço")
               .HasColumnType("VARCHAR")
               .HasMaxLength(125);

            builder.Property(x => x.Telefone)
               .IsRequired()
               .HasColumnName("Telefone")
               .HasColumnType("INT")
               .HasMaxLength(11);
        }
    }
}
