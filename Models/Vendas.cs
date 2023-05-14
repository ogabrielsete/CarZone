using System.ComponentModel.DataAnnotations;

namespace CarZone.Models
{
    public class Vendas
    {
        [Key]
        public int Id { get; set; }
        public int DataVenda { get; set; }


        public int PagamentoId { get; set; }


        public int VeiculoId { get; set; }
        public virtual Veiculos Veiculos { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
