using CarZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Map
{
    public class MarcasMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            // Tabela
            builder.ToTable("Marcas");

            // Chave Primaria
            builder.HasKey(x => x.Id);

            // Identity
            //builder.property(x => x.id)
            //    .valuegeneratedonadd()
            //    .useidentitycolumn();

            // Propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            
            
        }
    }
}
