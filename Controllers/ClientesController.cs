using CarZone.Models;
using CarZone.Validators;
using Microsoft.AspNetCore.Mvc;
using CarZone.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CarZone.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IVendasRepositorio _vendasRepositorio;
        private readonly ValidadorDeCPF _validadorDeCPF;
        public ClientesController(IClienteRepositorio clienteRep,
                                  IVendasRepositorio vendasRepositorio,
                                  ValidadorDeCPF validadorDeCPF)
        {
            _clienteRepositorio = clienteRep;
            _vendasRepositorio = vendasRepositorio;
            _validadorDeCPF = validadorDeCPF;

        }
        public IActionResult Index()
        {
            List<Cliente> mostrarClientes = _clienteRepositorio.GetAll();
            return View(mostrarClientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult AlterarCliente(int id)
        {
            Cliente cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                Cliente listarCliente = _clienteRepositorio.ListarPorId(id);

                bool clienteRelacionado = _vendasRepositorio.VendaRelacionada(listarCliente.Id);

                if (clienteRelacionado)
                    return RedirectToAction("Index", 
                        TempData["MensagemErro"] = "Não é possível excluir este cliente porque está relacionada a uma venda cadastrada.");


                _clienteRepositorio.Apagar(id);
                return RedirectToAction("Index", TempData["MensagemSucesso"] = "Cliente excluído com sucesso!");
            }

            catch (Exception error)
            {
                return RedirectToAction("Index", TempData["MensagemErro"] = $"Ocorreu um erro ao tentar excluir a venda. Detalhe: {error.Message}");
            }

        }

        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Vendas");

            try
            {
                if (ModelState.IsValid)
                {
                    cliente.CPF = cliente.CPF.Replace(".", "").Replace("-", "");
                    cliente.Telefone = cliente.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                    if (!_validadorDeCPF.ValidarCPF(cliente.CPF))
                    {

                        ModelState.AddModelError("CPF", "CPF inválido");
                        return View("Criar", cliente);
                    }

                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Não conseguimos cadastrar o cliente, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(Cliente cliente)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Vendas");

            try
            {
                if (ModelState.IsValid)
                {
                    if (!_validadorDeCPF.ValidarCPF(cliente.CPF))
                    {
                        ModelState.AddModelError("CPF", "CPF inválido");
                        return View("Criar", cliente);
                    }

                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Não conseguimos alterar o cliente, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

