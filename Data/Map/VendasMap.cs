﻿using CarZone.Models;
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
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.DataVenda)
                .IsRequired()
                .HasColumnName("DataVenda")
                .HasColumnType("datetime")
                .HasMaxLength(10);

            builder.Property(x => x.Meses)
                .IsRequired()
                .HasColumnName("Meses")
                .HasColumnType("int");

            builder.Property(x => x.VendedorId)                
                .HasColumnName("VendedorId")
                .HasColumnType("nvarchar(450)");

            // Relacionamentos com a tabela "Pagamentos"
            builder.HasOne(x => x.Pagamento)
                .WithMany()
                .HasForeignKey(x => x.PagamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamentos com a tabela "Veiculos"
            builder.HasOne(x => x.Modelo)
                .WithMany()
                .HasForeignKey(x => x.ModeloId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamentos com a tabela "Marcas"
            builder.HasOne(x => x.Marca)
                .WithMany()
                .HasForeignKey(x => x.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Vendedor)
                .WithMany()
                .HasForeignKey(x => x.VendedorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
