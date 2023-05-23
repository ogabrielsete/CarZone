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

        [Required]
        [MinLength(3)]
        [Column("Name", TypeName ="NVARCHAR")]
        public string Nome { get; set; }

        [Required]
        public int CPF { get; set; }

        [Required]
        [Column("Endereço", TypeName = "VARCHAR")]
        public string Endereco { get; set; }

        [Required]
        public int Telefone { get; set; }
    }
}
