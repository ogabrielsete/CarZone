using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    public class ModeloVeiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NomeModelo { get; set; }


        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

    }
}
