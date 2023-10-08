using CarZone.Data;
using CarZone.Models;
using CarZone.Models.ViewModels;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CarZone.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private readonly BancoContext _bancoContext;

        public HomeController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }

        public async Task<IActionResult> Index()
        {
            int totalClientes = _bancoContext.ClientesDB.Count();
            int totalVeiculos = _bancoContext.VeiculosDB.Count();
            int totalVendas = _bancoContext.VendasDB.Count();


            HomepageVM viewModel = new HomepageVM
            {
                TotalClientes = totalClientes,
                TotalVeiculos = totalVeiculos,
                TotalVendas = totalVendas
            };

            return View(viewModel);

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier ?? "N/A";
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}