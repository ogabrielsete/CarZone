using CarZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Map
{
    public class ModeloVeiculoMap : IEntityTypeConfiguration<ModeloVeiculo>
    {
        public void Configure(EntityTypeBuilder<ModeloVeiculo> builder)
        {
            // Tabela
            builder.ToTable("ModeloVeiculo");

            // Chave Primaria
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.NomeModelo)
                .HasColumnName("Modelo")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);


            //  Relacionamentos
            builder.HasOne(x => x.Marca)
                .WithMany(x => x.Modelos)
                .HasForeignKey(x => x.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
