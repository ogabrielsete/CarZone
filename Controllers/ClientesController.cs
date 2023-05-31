using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClientesController(IClienteRepositorio clienteRep)
        {
            _clienteRepositorio = clienteRep;
        }
        public IActionResult Index()
        {
            List<Cliente> mostrarClientes = _clienteRepositorio.GetAll();
            return View(mostrarClientes);
        }

        public IActionResult CadastrarCliente()
        {
            return View();
        }

        public IActionResult AlterarCliente(int id)
        {
            Cliente cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Cliente cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult Apagar(int id)
        {
            _clienteRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            _clienteRepositorio.Adicionar(cliente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(Cliente cliente)
        {
            _clienteRepositorio.Atualizar(cliente);
            return RedirectToAction("Index");
        }



    }
}
