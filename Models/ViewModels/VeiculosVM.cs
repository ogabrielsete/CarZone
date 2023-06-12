using CarZone.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarZone.Models.ViewModels
{
    public class VeiculosVM
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }  
        public double Preco { get; set; }
        public StatusVenda StatusVenda { get; set; }
        public int MarcaId { get; set; }
        public string Marca { get; set; }
        public int ModeloId { get; set; }
        public string Modelo { get; set; }
    }
}
