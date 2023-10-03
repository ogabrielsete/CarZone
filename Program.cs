using CarZone.Data;
using CarZone.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Identity;
using CarZone.Services;

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
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BancoContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddSession();



            builder.Services.AddScoped<IVeiculosRepositorio, VeiculosRepositorio>();
            builder.Services.AddScoped<IMarcasRepositorio, MarcasRepositorio>();
            builder.Services.AddScoped<IModeloVeiculosRepositorio, ModeloVeiculosRepositorio>();
            builder.Services.AddScoped<IMarcasRepositorio, MarcasRepositorio>();
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            builder.Services.AddScoped<IVendasRepositorio, VendasRepositorio>();
            builder.Services.AddScoped<IPagamentosRepositorio, PagamentoRepositorio>();
            builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IEmailService, MailgunEmailService>();

            builder.Services.AddAuthorization();
            builder.Services.AddHttpClient();

            var secret = builder.Configuration["SecretsStuff:codeA"];
            var otherSecret = builder.Configuration["SecretsStuff:codeD"];

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

            CriarPerfisUsuarios(app);


            app.UseSession();


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            });



            app.Run();

            void CriarPerfisUsuarios(WebApplication app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
                    service.SeedUsers();
                    service.SeedRoles();
                }
            }
        }
    }
}