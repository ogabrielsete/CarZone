using CarZone.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarZone.Models.ViewModels
{
    public class VeiculosVM
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Preco { get; set; }
        public StatusVenda StatusVenda { get; set; }
        public int MarcaId { get; set; }
        [Required(ErrorMessage = "Selecione o veículo!")]
        public string Marca { get; set; }
        public int ModeloId { get; set; }
        public string Modelo { get; set; }
    }
}
