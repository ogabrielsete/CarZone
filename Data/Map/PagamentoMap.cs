using CarZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Map
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {

            // Tabela
            builder.ToTable("Pagamento");

            // Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.NomePagamento)
                       .IsRequired()
                       .HasColumnName("NomePagamento")
                       .HasColumnType("NVARCHAR")
                       .HasMaxLength(100);

            
            builder.Property(x => x.CategoriaVeiculo)
                .IsRequired()
                .HasColumnName("Categoria")
                .HasColumnType("int");

        }
    }
}
