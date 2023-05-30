using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarZone.Controllers
{
    public class VendasController : Controller
    {
        private readonly IVendasRepositorio _vendasRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IModeloVeiculosRepositorio _modeloVeiculosRepositorio;
        private readonly IPagamentosRepositorio _pagamentosRepositorio;
        public VendasController(IVendasRepositorio vendasRepositorio,
                                IClienteRepositorio clienteRepositorio,
                                   IModeloVeiculosRepositorio modeloVeiculosRepositorio,
                                    IPagamentosRepositorio pagamentosRepositorio)
        {
            _vendasRepositorio = vendasRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _modeloVeiculosRepositorio = modeloVeiculosRepositorio;
            _pagamentosRepositorio = pagamentosRepositorio;
        }
        public IActionResult Index()
        {
            List<Venda> mostrarVendas = _vendasRepositorio.GetAll();
            return View(mostrarVendas);
        }

        public IActionResult CadastrarVenda()
        {
            var dropDownCliente = _clienteRepositorio.GetAll();
            ViewBag.Clientes = new SelectList(dropDownCliente, "Id", "Nome");

            var dropDownModelos = _modeloVeiculosRepositorio.GetAll();
            ViewBag.Modelos = new SelectList(dropDownModelos, "Id", "NomeModelo");

            var dropDownPagamentos = _pagamentosRepositorio.GetAll();
            ViewBag.Pag = new SelectList(dropDownPagamentos, "Id", "NomePagamento");

            return View();
        }

        public IActionResult EditarVenda(int id)
        {
            var dropDownCliente = _clienteRepositorio.GetAll();
            ViewBag.Clientes = new SelectList(dropDownCliente, "Id", "Nome");

            var dropDownModelos = _modeloVeiculosRepositorio.GetAll();
            ViewBag.Modelos = new SelectList(dropDownModelos, "Id", "NomeModelo");

            var dropDownPagamentos = _pagamentosRepositorio.GetAll();
            ViewBag.Pag = new SelectList(dropDownPagamentos, "Id", "NomePagamento");

            Venda editarVenda = _vendasRepositorio.ListarPorId(id);
            return View(editarVenda);
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Venda vendas)
        {
            _vendasRepositorio.Adicionar(vendas);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar (Venda vendas)
        {
            _vendasRepositorio.Atualizar(vendas);
            return RedirectToAction("Index");
        }
    }
}
