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
        public DbSet<Vendas> VendasDB { get; set; }
        public DbSet<Veiculos> VeiculosDB { get; set; }
        public DbSet<Marcas> MarcasDB { get; set; }
        public DbSet<ModeloVeiculos> ModeloVeiculosDB { get; set; }
        public DbSet<Pagamento> PagamentosDB { get; set; }

    }
}
