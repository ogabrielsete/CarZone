
using CarZone.Models;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    [Authorize]
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
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult EditarPagamento(int id)
        {
            Pagamento editarPag = _pagamentosRepositorio.ListarPorId(id);
            return View(editarPag);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            Pagamento pag = _pagamentosRepositorio.ListarPorId(id);
            return View(pag);
        }
        public IActionResult Apagar(int id)
        {
            _pagamentosRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Criar(Pagamento pagamento)
        {
            ModelState.Remove("Id");

            try
            {
                if (ModelState.IsValid)
                {
                    _pagamentosRepositorio.Adicionar(pagamento);
                    TempData["MensagemSucesso"] = "Pagamento cadastrado com sucesso";

                    return RedirectToAction("Index");
                }

                return View(pagamento);
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu pagamento, tente novamente. Detalhe: {error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(Pagamento pagamento)
        {
            ModelState.Remove("Id");

            try
            {
                if (ModelState.IsValid)
                {
                    _pagamentosRepositorio.Atualizar(pagamento);
                    TempData["MensagemSucesso"] = "Forma de pagamento alterado com sucesso";

                    return RedirectToAction("Index");
                }

                return View(pagamento);
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu pagamento, tente novamente. Detalhe: {error.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
