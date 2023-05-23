using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Nome", TypeName = "VARCHAR")]
        public string Nome { get; set; }

       public IList<ModeloVeiculo> Modelos { get; set; }
    }
}