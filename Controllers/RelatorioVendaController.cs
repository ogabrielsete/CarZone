using CarZone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    [Authorize]
    public class RelatorioVendaController : Controller
    {
        private readonly RelatorioVendaService _relatorioService;
        private readonly UserManager<IdentityUser> _userManager;

        public RelatorioVendaController(RelatorioVendaService relatorioService, UserManager<IdentityUser> userManager)
        {
            _relatorioService = relatorioService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var vendasPorData = await _relatorioService.FindByDateAsync(null, null);
            foreach (var venda in vendasPorData)
            {
                if(venda.VendedorId != null)
                {
                    var nomeVendedor = _userManager.FindByIdAsync(venda.VendedorId).Result;
                    venda.VendedorId = nomeVendedor.UserName;
                }
            }
            return View(vendasPorData);
        }

        public async Task<IActionResult> RelatorioVendaSimples(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var resultaConsulta = await _relatorioService.FindByDateAsync(minDate, maxDate);
            foreach (var venda in resultaConsulta)
            {
                if (venda.VendedorId != null)
                {
                    var nomeVendedor = await _userManager.FindByIdAsync(venda.VendedorId);
                    venda.VendedorId = nomeVendedor.UserName;
                }
            }
            return View(resultaConsulta);

        }
    }
}
