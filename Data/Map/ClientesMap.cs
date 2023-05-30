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
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();


            // Propriedades
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd(); 

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CPF)
                .HasColumnName("CPF")
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired()
                .HasAnnotation("RegularExpression", @"\d{11}")
                .HasAnnotation("RegularExpressionErrorMessage", "O CPF deve conter apenas dígitos.");

            builder.Property(x => x.Endereco)
               .HasColumnName("Endereço")
               .HasColumnType("VARCHAR")
               .HasMaxLength(125)
               .IsRequired();

            builder.Property(x => x.Telefone)
               .HasColumnName("Telefone")
               .HasColumnType("varchar")
               .HasMaxLength(11)
               .IsRequired()
               .HasAnnotation("RegularExpression", @"\d{11}")
                .HasAnnotation("RegularExpressionErrorMessage", "O telefone deve conter apenas dígitos.");
        }
    }
}
