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
        public int Ano { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "{0} é necessário")]
        [Range(0, 1000000,
        ErrorMessage = "Valor deve ser maior que zero")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Status de Venda é necessário")]
        public StatusVenda StatusVenda { get; set; }


        [Required(ErrorMessage = "Selecione a Marca!")]
        public int MarcaId { get; set; }

        public Marca Marca { get; set; }


        [Required(ErrorMessage = "Selecione o modelo!")]
        public int ModeloId { get; set; }
        public ModeloVeiculo Modelo { get; set; }


    }
}
