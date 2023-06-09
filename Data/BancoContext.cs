﻿using CarZone.Data.Map;
using CarZone.Models;
using Microsoft.EntityFrameworkCore;

namespace CarZone.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<Cliente> ClientesDB { get; set; }
        public DbSet<Venda> VendasDB { get; set; }
        public DbSet<Veiculo> VeiculosDB { get; set; }
        public DbSet<Marca> MarcasDB { get; set; }
        public DbSet<ModeloVeiculo> ModeloVeiculosDB { get; set; }
        public DbSet<Pagamento> PagamentosDB { get; set; }
        public DbSet<Usuario> UsuarioDB { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        //    options.UseSqlServer("Data Source = GABRIEL\\SQLEXPRESS; Initial Catalog = DB_Carzone; Integrated Security = True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModeloVeiculoMap());
            modelBuilder.ApplyConfiguration(new VeiculosMap());
            modelBuilder.ApplyConfiguration(new VendasMap());
            modelBuilder.ApplyConfiguration(new MarcasMap());
            modelBuilder.ApplyConfiguration(new PagamentoMap());
            modelBuilder.ApplyConfiguration(new ClientesMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
