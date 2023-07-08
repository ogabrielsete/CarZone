using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CarZone.Models
{
    [Table("Venda")]
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Insira uma data")]
        public DateTime DataVenda { get; set; }

        [Required(ErrorMessage= "Insira uma quantidade de meses")]
        [Range(0, double.MaxValue, ErrorMessage = "O número de meses deve ser maior que zero.")]
        public int Meses { get; set; }

        [Required(ErrorMessage = "Escolha um cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        [Required(ErrorMessage = "Escolha um tipo de pagamento")]
        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }

        [Required(ErrorMessage = "Selecione a Marca!")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        [Required(ErrorMessage = "Escolha um modelo de veiculo")]
        public int ModeloId { get; set; }
        public ModeloVeiculo Modelo { get; set; }

    }
}
