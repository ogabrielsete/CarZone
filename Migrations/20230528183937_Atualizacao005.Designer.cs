﻿// <auto-generated />
using CarZone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarZone.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20230528183937_Atualizacao005")]
    partial class Atualizacao005
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarZone.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("INT")
                        .HasColumnName("CPF");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("VARCHAR(125)")
                        .HasColumnName("Endereço");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Nome");

                    b.Property<int>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("INT")
                        .HasColumnName("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("CarZone.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Marcas", (string)null);
                });

            modelBuilder.Entity("CarZone.Models.ModeloVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("NomeModelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Modelo");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("ModeloVeiculo", (string)null);
                });

            modelBuilder.Entity("CarZone.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaVeiculo")
                        .HasColumnType("int")
                        .HasColumnName("Categoria");

                    b.Property<int>("Meses")
                        .HasMaxLength(3)
                        .HasColumnType("INT")
                        .HasColumnName("Meses");

                    b.Property<string>("NomePagamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("NomePagamento");

                    b.HasKey("Id");

                    b.ToTable("Pagamento", (string)null);
                });

            modelBuilder.Entity("CarZone.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasMaxLength(4)
                        .HasColumnType("INT")
                        .HasColumnName("Ano");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("VARCHAR(7)")
                        .HasColumnName("Placa");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Preco");

                    b.Property<int>("StatusVenda")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ModeloId");

                    b.ToTable("Veiculos", (string)null);
                });

            modelBuilder.Entity("CarZone.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("DataVenda")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasColumnName("DataVenda");

                    b.Property<int>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PagamentoId");

                    b.HasIndex("VeiculoId")
                        .IsUnique();

                    b.ToTable("Venda", (string)null);
                });

            modelBuilder.Entity("CarZone.Models.ModeloVeiculo", b =>
                {
                    b.HasOne("CarZone.Models.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("CarZone.Models.Veiculo", b =>
                {
                    b.HasOne("CarZone.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarZone.Models.ModeloVeiculo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("CarZone.Models.Venda", b =>
                {
                    b.HasOne("CarZone.Models.Cliente", "Cliente")
                        .WithMany("Vendas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarZone.Models.Pagamento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarZone.Models.Veiculo", "Veiculo")
                        .WithOne("Venda")
                        .HasForeignKey("CarZone.Models.Venda", "VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Pagamento");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("CarZone.Models.Cliente", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("CarZone.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("CarZone.Models.Veiculo", b =>
                {
                    b.Navigation("Venda")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
