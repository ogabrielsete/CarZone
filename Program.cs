using CarZone.Data;
using CarZone.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace CarZone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(options =>
                options.UseSqlServer("Data Source = GABRIEL\\SQLEXPRESS; Initial Catalog = DB_Carzone; Integrated Security = True"));
            builder.Services.AddScoped<IVeiculosRepositorio, VeiculosRepositorio>();
            builder.Services.AddScoped<IMarcasRepositorio, MarcasRepositorio>();
            builder.Services.AddScoped<IModeloVeiculosRepositorio, ModeloVeiculosRepositorio>();
            builder.Services.AddScoped<IMarcasRepositorio, MarcasRepositorio>();
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            builder.Services.AddScoped<IVendasRepositorio, VendasRepositorio>();
            builder.Services.AddScoped<IPagamentosRepositorio, PagamentoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}