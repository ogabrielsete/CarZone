using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    [Table("ModeloVeiculo")]
    public class ModeloVeiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Modelo", TypeName = "NVARCHAR")]
        public string Modelo { get; set; }


        [ForeignKey("MarcaId")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
