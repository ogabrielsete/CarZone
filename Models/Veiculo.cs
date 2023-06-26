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

        [Required(ErrorMessage = "{0} é necessário")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "{0} é necessário")]
        [Range(1990, int.MaxValue, ErrorMessage = "O ano do carro deve ser igual ou maior que 1990.")]
        [AnoMaximo]
        public int Ano { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "Preço é necessário")]
        [Range(0, 1000000, ErrorMessage = "Valor deve ser maior que zero")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Status de Venda é necessário")]
        [Range(1, int.MaxValue, ErrorMessage = "Escolha o status do veículo")]
        public StatusVenda StatusVenda { get; set; }


        [Required(ErrorMessage = "Selecione a Marca!")]
        public int MarcaId { get; set; }

        public Marca Marca { get; set; }


        [Required(ErrorMessage = "Selecione o modelo!")]
        public int ModeloId { get; set; }
        public ModeloVeiculo Modelo { get; set; }

        ////////////////////////////

        public class AnoMaximoAttribute : ValidationAttribute
        {
            public AnoMaximoAttribute()
            {
                ErrorMessage = "O ano do carro deve ser no máximo dois anos acima do ano atual.";
            }

            public override bool IsValid(object value)
            {
                if (value is int intValue)
                {
                    return intValue <= DateTime.Now.Year + 2;
                }
                return false;
            }
        }

    }
}
