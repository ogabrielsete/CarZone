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
        public string Placa { get; set; }
        public int Ano { get; set; }
        public double Preco { get; set; }
        public StatusVenda StatusVenda { get; set; }


        public int MarcaId { get; set; }
        public Marca Marca { get; set; }


        public int ModeloId { get; set; }
        public ModeloVeiculo Modelo { get; set; }


        public Venda Venda { get; set; }


    }
}
