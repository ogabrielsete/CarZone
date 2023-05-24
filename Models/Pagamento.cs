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

        [Required]
        [Column("Pagamento", TypeName = "VARCHAR")]
        public string NomePagamento { get; set; }

        public int Meses { get; set; }

        public CategoriaVeiculo CategoriaVeiculo { get; set; }
    }
}
