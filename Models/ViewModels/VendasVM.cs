﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CarZone.Models.ViewModels
{
    public class VendasVM
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVenda { get; set; }

        public int Meses { get; set; }

        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public decimal ValorVenda { get; set; }
        public int PagamentoId { get; set; }
        public string Pagamento { get; set; }
        public int ModeloId { get; set; }
        public string Modelo { get; set; }
        public int MarcaId { get; set; }
        public string Marca { get; set; }

        public string? VendedorId { get; set; }
        public IdentityUser? Vendedor { get; set; }
    }
}
