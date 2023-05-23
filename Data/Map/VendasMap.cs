using CarZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarZone.Data.Map
{
    public class VendasMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {

            // Tabela
            builder.ToTable("Venda");

            // Primária
            builder.HasKey( x => x.Id );

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.DataVenda)
                .IsRequired()
                .HasColumnName("DataVenda")
                .HasColumnType("int")
                .HasMaxLength(10);

            // Relacionamentos
            builder.HasOne(x => x.Cliente);
            builder.HasOne(x => x.Pagamento);
            builder.HasOne(x => x.Veiculo);

        }
    }
}
