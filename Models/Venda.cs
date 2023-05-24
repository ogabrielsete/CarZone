using CarZone.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    [Table("Venda")]
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int DataVenda { get; set; }


        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }



        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }



        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

    }
}
