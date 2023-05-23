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

        [Required]
        public int DataVenda { get; set; }

        public StatusVenda Status { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("PagamentoId")]
        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }

        [ForeignKey("VeiculoId")]
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

    }
}
