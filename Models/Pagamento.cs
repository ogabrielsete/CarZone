using CarZone.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Adicione um método de pagamento")]
        [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "O nome do pagamento deve conter apenas letras.")]
        [StringLength(50, ErrorMessage = "O nome do pagamento deve ter no máximo 50 caracteres.")]
        public string NomePagamento { get; set; }

        [Required(ErrorMessage = "Escolha a categoria do veículo")]
        [Range(1, int.MaxValue, ErrorMessage = "Escolha a categoria do veículo")]
        public CategoriaVeiculo CategoriaVeiculo { get; set; }
    }
}
