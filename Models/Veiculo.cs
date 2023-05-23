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

        [Required]
        [Column("Placa", TypeName = "VARCHAR")]
        public string Placa { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public double Preco { get; set; }

        public StatusVenda StatusVenda { get; set; }

        [ForeignKey("MarcaId")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        [ForeignKey("Modelo Id")]
        public int ModelosId { get; set; }
        public ModeloVeiculo ModeloVeiculo { get; set; }

        


    }
}
