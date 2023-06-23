using CarZone.Models;
using CarZone.Models.ViewModels;
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
            var listarPagamento = _pagamentosRepositorio.GetAll();
            var listarModelo = _modeloVeiculosRepositorio.GetAll();
            var listarCliente = _clienteRepositorio.GetAll();

            var listarVendas = new List<VendasVM>();
            List<Venda> vendas = _vendasRepositorio.GetAll();
            foreach (var item in vendas)
            {
                var listar = new VendasVM();
                listar.DataVenda = item.DataVenda;
                listar.Id = item.Id;
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
            try
            {
                // Dados válidos, Adiciona ao repositório e redireciona para a Lista de Vendas
                _vendasRepositorio.Adicionar(venda);
                TempData["MensagemSucesso"] = "Venda cadastrada com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

                TempData["MensagemErro"] = $"Não conseguimos cadastrar sua venda, tente novamente. Detalhe: {error.Message}"; 
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public IActionResult Editar(Venda vendas)
        {
            _vendasRepositorio.Atualizar(vendas);
            return RedirectToAction("Index");
        }


        private bool DadosInvalidos(Venda venda)
        {
            return venda.ModeloId == 0 || venda.ClienteId == 0 || venda.PagamentoId == 0;
        }
    }
}
