﻿using Microsoft.AspNetCore.Mvc;

namespace CarZone.Controllers
{
    public class VendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarVenda()
        {
            return View();
        }

        public IActionResult EditarVenda()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
    }
}
