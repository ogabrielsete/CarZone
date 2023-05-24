using CarZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Map
{
    public class VeiculosMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            // Tabela
            builder.ToTable("Veiculos");

            // Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Ano)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnType("INT")
                .HasColumnName("Ano");


            builder.Property(x => x.Placa)
                .IsRequired()
                .HasMaxLength(7)
                .HasColumnType("VARCHAR")
                .HasColumnName("Placa");

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasColumnName("Preco");

            builder.Property(x => x.StatusVenda)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Status");

            // Relacionamento com a tabela Marcas
            builder.HasOne(x => x.Marca)
                .WithMany()
                .HasForeignKey(x => x.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com a tabela Modelo
            builder.HasOne(x => x.Modelo)
                .WithMany()
                .HasForeignKey(x => x.ModeloId)
                .OnDelete(DeleteBehavior.Restrict);  

        }
    }
}
