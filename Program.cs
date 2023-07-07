using CarZone.Data;
using CarZone.Helper;
using CarZone.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<IVeiculosRepositorio, VeiculosRepositorio>();
            builder.Services.AddScoped<IMarcasRepositorio, MarcasRepositorio>();
            builder.Services.AddScoped<IModeloVeiculosRepositorio, ModeloVeiculosRepositorio>();
            builder.Services.AddScoped<IMarcasRepositorio, MarcasRepositorio>();
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            builder.Services.AddScoped<IVendasRepositorio, VendasRepositorio>();
            builder.Services.AddScoped<IPagamentosRepositorio, PagamentoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ISessao, Sessao>();
            builder.Services.AddScoped<IEmail, Email>();

            builder.Services.AddMvc().AddRazorPagesOptions(options =>
             {
                 options.Conventions.AddPageRoute("/Home/Index", "");
             }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            builder.Services.AddSession(x =>
            {
                x.Cookie.HttpOnly = true;
                x.Cookie.IsEssential = true;
            });



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

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}