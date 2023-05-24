using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido.")]
        public int CPF { get; set; }

        [Required]
        [Column("Endereço", TypeName = "VARCHAR")]
        public string Endereco { get; set; }

        [Required]
        [RegularExpression(@"^\(\d{2}\)\s*\d{4,5}-\d{4}$", ErrorMessage = "O campo Telefone deve estar no formato (99) 99999-9999.")]
        public int Telefone { get; set; }

        public ICollection<Venda>  Vendas { get; set; }
    }
}
