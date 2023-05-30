using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly IPagamentosRepositorio _pagamentosRepositorio;
        public PagamentosController(IPagamentosRepositorio pagamentosRepositorio)
        {
            _pagamentosRepositorio = pagamentosRepositorio;
        }

        public IActionResult Index()
        {
            List<Pagamento> listarPagamentos = _pagamentosRepositorio.GetAll();
            return View(listarPagamentos);
        }
        public IActionResult CriarPagamento()
        {
            return View();
        }

        public IActionResult EditarPagamento(int id)
        {
            Pagamento editarPag = _pagamentosRepositorio.ListarPorId(id);
            return View(editarPag);
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Pagamento criarPagamento)
        {
            _pagamentosRepositorio.Adicionar(criarPagamento);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Pagamento criarPagamento)
        {
            _pagamentosRepositorio.Atualizar(criarPagamento);
            return RedirectToAction("Index");
        }
    }
}
