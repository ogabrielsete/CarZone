using CarZone.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using static CarZone.Models.Veiculo;

namespace CarZone.Models.ViewModels
{
    public class VeiculosVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é necessário")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "{0} é necessário")]
        [Range(1990, int.MaxValue, ErrorMessage = "O ano do carro deve ser igual ou maior que 1990.")]
        [AnoMaximo(ErrorMessage = "O ano do carro deve ser no máximo um ano acima do ano atual.")]
        public int Ano { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "{0} é necessário")]
        [Range(0, 1000000, ErrorMessage = "Valor deve ser maior que zero")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Status de Venda é necessário")]
        public StatusVenda StatusVenda { get; set; }

        [Required(ErrorMessage = "Selecione a Marca!")]
        public int MarcaId { get; set; }
        public string Marca { get; set; }

        [Required(ErrorMessage = "Selecione o modelo!")]
        public int ModeloId { get; set; }
        public string Modelo { get; set; }

    }
}
