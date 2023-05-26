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

        public IActionResult AlterarCliente()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            _clienteRepositorio.Adicionar(cliente);
            return View("Index");
        }
    }
}
