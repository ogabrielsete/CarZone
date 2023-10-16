using CarZone.Models;
using CarZone.Models.ViewModels;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace CarZone.Controllers
{
    [Authorize]

    public class VendasController : Controller
    {
        private readonly IVendasRepositorio _vendasRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IModeloVeiculosRepositorio _modeloVeiculosRepositorio;
        private readonly IPagamentosRepositorio _pagamentosRepositorio;
        private readonly IMarcasRepositorio _marcasRepositorio;
        private readonly UserManager<IdentityUser> _userManager;
        public VendasController(IVendasRepositorio vendasRepositorio,
                                IClienteRepositorio clienteRepositorio,
                                   IModeloVeiculosRepositorio modeloVeiculosRepositorio,
                                    IPagamentosRepositorio pagamentosRepositorio,
                                    IMarcasRepositorio marcasRepositorio,
                                    UserManager<IdentityUser> userManager)
        {
            _vendasRepositorio = vendasRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _modeloVeiculosRepositorio = modeloVeiculosRepositorio;
            _pagamentosRepositorio = pagamentosRepositorio;
            _marcasRepositorio = marcasRepositorio;
            _userManager = userManager;


        }
        public IActionResult Index()
        {
            var listarPagamento = _pagamentosRepositorio.GetAll();
            var listarModelo = _modeloVeiculosRepositorio.GetAll();
            var listarCliente = _clienteRepositorio.GetAll();
            var listarMarca = _marcasRepositorio.GetAll();

            var listarVendas = new List<VendasVM>();
            List<Venda> vendas = _vendasRepositorio.GetAll();            
            foreach (var item in vendas)
            {
                var listar = new VendasVM();
                listar.DataVenda = item.DataVenda;
                listar.Id = item.Id;
                listar.Marca = listarMarca.FirstOrDefault(x => x.Id == item.MarcaId).Nome;
                listar.Modelo = listarModelo.FirstOrDefault(x => x.Id == item.ModeloId).NomeModelo;
                listar.Cliente = listarCliente.FirstOrDefault(x => x.Id == item.ClienteId).Nome;
                listar.Pagamento = listarPagamento.FirstOrDefault(x => x.Id == item.PagamentoId).NomePagamento;
                listar.Meses = item.Meses;


                listarVendas.Add(listar);
            }

            return View(listarVendas);
        }

        public IActionResult Criar()
        {
            var dropDownCliente = _clienteRepositorio.GetAll();
            ViewBag.Clientes = new SelectList(dropDownCliente, "Id", "Nome");

            var dropDownMarcas = _marcasRepositorio.GetAll();
            ViewBag.Marcas = new SelectList(dropDownMarcas, "Id", "Nome");

            var dropDownModelos = _modeloVeiculosRepositorio.GetAll();
            ViewBag.Modelos = new SelectList(dropDownModelos, "Id", "NomeModelo");

            var dropDownPagamentos = _pagamentosRepositorio.GetAll();
            ViewBag.Pag = new SelectList(dropDownPagamentos, "Id", "NomePagamento");

            return View();
        }

        public IActionResult Editar(int id)
        {
            var dropDownCliente = _clienteRepositorio.GetAll();
            ViewBag.Clientes = new SelectList(dropDownCliente, "Id", "Nome");

            var dropDownMarcas = _marcasRepositorio.GetAll();
            ViewBag.Marcas = new SelectList(dropDownMarcas, "Id", "Nome"); 

            var dropDownModelos = _modeloVeiculosRepositorio.GetAll();
            ViewBag.Modelos = new SelectList(dropDownModelos, "Id", "NomeModelo");

            var dropDownPagamentos = _pagamentosRepositorio.GetAll();
            ViewBag.Pag = new SelectList(dropDownPagamentos, "Id", "NomePagamento");

            Venda editarVenda = _vendasRepositorio.ListarPorId(id);
            return View(editarVenda);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Venda vendas = _vendasRepositorio.ListarPorId(id);
            return View(vendas);
        }
        public IActionResult Apagar(int id)
        {
            _vendasRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Criar(Venda venda)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Modelo");
            ModelState.Remove("Pagamento");
            ModelState.Remove("Cliente");
            ModelState.Remove("Marca");

            try
            {
                if (ModelState.IsValid)
                {
                    // Dados válidos, Adiciona ao repositório e redireciona para a Lista de Vendas
                    venda.VendedorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _vendasRepositorio.Adicionar(venda);
                    TempData["MensagemSucesso"] = "Venda cadastrada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(venda);
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos cadastrar sua venda, tente novamente. Detalhe: {error.Message}"; 
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(Venda venda)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Modelo");
            ModelState.Remove("Pagamento");             
            ModelState.Remove("Cliente");
            ModelState.Remove("Marca");

            try
            {
                if (ModelState.IsValid)
                {
                    // Dados válidos, Adiciona ao repositório e redireciona para a Lista de Vendas
                    _vendasRepositorio.Atualizar(venda);
                    TempData["MensagemSucesso"] = "Venda alterada com sucesso";

                    return RedirectToAction("Index");
                }
                return View(venda);

            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos alterar sua venda, tente novamente. Detalhe: {error.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
