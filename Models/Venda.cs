using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required(ErrorMessage = "Insira uma quantidade de meses")]
        [Range(1, int.MaxValue, ErrorMessage = "O número de meses deve ser maior que zero.")]
        public int Meses { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "Preço é necessário")]
        [Range(0.01, 1000000, ErrorMessage = "Valor deve ser maior que zero")]
        public decimal ValorVenda { get; set; }

        [Required(ErrorMessage = "Escolha um cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Escolha um tipo de pagamento")]
        public int PagamentoId { get; set; }
        public virtual Pagamento Pagamento { get; set; }

        [Required(ErrorMessage = "Selecione a Marca!")]
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }

        [Required(ErrorMessage = "Escolha um modelo de veiculo")]
        public int ModeloId { get; set; }
        public virtual ModeloVeiculo Modelo { get; set; }

        public string? VendedorId { get; set; }

        [ForeignKey("VendedorId")]
        public virtual IdentityUser? Vendedor { get; set; }

    }
}
