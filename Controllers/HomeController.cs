using CarZone.Data;
using CarZone.Models;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CarZone.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ITarefasRepositorio _tarefaRepositorio;
        private readonly BancoContext _bancoContext;

        public HomeController(ITarefasRepositorio tarefaRepositorio,
                                BancoContext bancoContext)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _bancoContext = bancoContext;

        }

        //public IActionResult Index()
        //{
        //    var tarefas = _bancoContext.TarefasDB.FirstOrDefault();
        //    return View(tarefas);
        //}

        public async Task<IActionResult> Index()
        {
            var todos = _bancoContext.TarefasDB.ToList();

            return View(todos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Tarefas todo)
        {
            await _bancoContext.TarefasDB.AddAsync(todo);
            await _bancoContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }


      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}