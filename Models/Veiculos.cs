using System.ComponentModel.DataAnnotations;

namespace CarZone.Models
{
    public class Veiculos
    {
        [Key]
        public int Id { get; set; }

        public int Placa { get; set; }

        public int Ano { get; set; }

        public bool StatusVenda { get; set; }

        public int MarcaId { get; set; } 
    }
}
