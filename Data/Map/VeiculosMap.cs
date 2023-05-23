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
            builder.ToTable("Veiculo");

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
                .HasColumnType("DECIMAL(18,2)")
                .HasColumnName("Preco");

            // Relacionamentos
            builder.HasOne(x => x.Marca)
                .WithMany()
                .HasForeignKey(x => x.MarcaId)
                .HasConstraintName("FK_Marca_Veiculo")
                .OnDelete(DeleteBehavior.Restrict);  //???                

            builder.HasOne(x => x.ModeloVeiculo)
                .WithMany()
                .HasForeignKey(x => x.ModelosId)
                .HasConstraintName("FK_Modelo_Veiculo")
                .OnDelete(DeleteBehavior.Restrict);  // ???




        }
    }
}
