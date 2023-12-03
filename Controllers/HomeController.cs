using CarZone.Data;
using CarZone.Models;
using CarZone.Models.ViewModels;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;
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

        [HttpPost]
        public JsonResult GetTotalVendas(DateTime? startDate, DateTime? endDate)
        {
            var vendasQuery = _bancoContext.VendasDB.AsQueryable();

            // Aplica os filtros de data se foram fornecidos
            if (startDate != null && endDate != null)
            {
                vendasQuery = vendasQuery.Where(x => x.DataVenda >= startDate && x.DataVenda <= endDate);
            }

            var vendas = vendasQuery.ToList();
            var clientes = _bancoContext.ClientesDB.ToList();

            var data = new
            {
                labels = vendas.OrderBy(x => x.DataVenda)
                               .Select(x => x.DataVenda.ToString("dd/MM/yy", new CultureInfo("pt-BR")))
                               .Distinct()
                               .ToList(),
                datasets = new object[]
                        {
            new
            {
                label = "Total de Vendas",
                data = vendas.OrderBy(x => x.DataVenda)
                              .GroupBy(x => x.DataVenda)
                              .Select(x => x.Count())
                              .ToList(),
                borderColor = "blue",
                borderWidth = 2,
                fill = false
            },
            new
            {
                label = "Valor Financeiro",
                data = vendas.OrderBy(x => x.DataVenda)
                              .GroupBy(x => x.DataVenda)
                              .Select(x => x.Sum(v => v.ValorVenda))
                              .ToList(),
                borderColor = "green",
                borderWidth = 2,
                fill = false
            },
            new
            {
                label = "Clientes",
                data = CalcularTodosOsClientes(clientes.Select(x => x.Id)
                                                        .ToList()),
                borderColor = "red",
                borderWidth = 2,
                fill = false
            }
                },

            };

            return Json(data);
        }

        private List<int> CalcularTodosOsClientes(List<int> clientes)
        {
            List<int> todosOsClientes = new List<int>();
            int total = 0;

            foreach (var cliente in clientes)
            {
                total++;
                todosOsClientes.Add(total);
            }

            // Preencha os valores ausentes para que a lista tenha o mesmo comprimento que as datas
            for (int i = 0; i < 12 - clientes.Count; i++)
            {
                todosOsClientes.Add(total);
            }

            return todosOsClientes;
        }

    }
}