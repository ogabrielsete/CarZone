using CarZone.Models;
using CarZone.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using static CarZone.Controllers.ClientesController;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

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

        public IActionResult Criar()
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
            ModelState.Remove("Id");
            ModelState.Remove("Vendas");

            try
            {
                if (ModelState.IsValid)
                {
                    cliente.CPF = cliente.CPF.Replace(".", "").Replace("-", "");
                    cliente.Telefone = cliente.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                    if (!ValidarCPF(cliente.CPF))
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
                    if (!ValidarCPF(cliente.CPF))
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


        public bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", ""); // Remove os caracteres especiais do CPF

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (caso contrário, é um CPF inválido)
            if (new string(cpf[0], 11) == cpf)
                return false;

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);

            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

            // Verifica se o primeiro dígito verificador está correto
            if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
                return false;

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);

            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : 11 - resto;

            // Verifica se o segundo dígito verificador está correto
            if (int.Parse(cpf[10].ToString()) != digitoVerificador2)
                return false;

            return true; // CPF válido
        }
    }
}

