using CarZone.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    [Table("Veiculo")]
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória")]
        [RegularExpression(@"^([A-Za-z]{3}\d{4}|[A-Za-z]{3}\d[A-Za-z]\d{2})$", ErrorMessage = "Formato de placa inválido")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O ano do veículo é obrigatório")]
        [Range(1990, int.MaxValue, ErrorMessage = "O ano do carro deve ser igual ou maior que 1990.")]
        [AnoMaximo]
        public int Ano { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0, 1000000, ErrorMessage = "O valor deve ser maior que zero")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O status de Venda é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Escolha o status do veículo")]
        public StatusVenda StatusVenda { get; set; }

        [Required(ErrorMessage = "Selecione a marca!")]
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }

        [Required(ErrorMessage = "Selecione o modelo!")]
        public int ModeloId { get; set; }
        public virtual ModeloVeiculo Modelo { get; set; }

    }
}
