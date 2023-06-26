using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    [Table("Marcas")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da marca é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome da marca não pode exceder 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s-]+$", ErrorMessage = "A marca deve conter apenas letras, espaços e hífens.")]
        public string Nome { get; set; }


        public ICollection<ModeloVeiculo> Modelos { get; set; }
    }
}