using System.ComponentModel.DataAnnotations;

namespace CarZone.Models
{
    public class Marcas
    {
        [Key]
        public int MarcaId { get; set; }
        public string MarcaNome { get; set; }


        
        public virtual Veiculos Veiculo { get; set; }
        public virtual ModeloVeiculos ModeloVeiculos { get; set; }
    }
}