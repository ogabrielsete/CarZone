namespace CarZone.Models
{
    public class Vendas
    {
        public int IdVendas { get; set; }
        public int DataVenda { get; set; }


        public int FinanciamentoId { get; set; }


        public int VeiculoId { get; set; }
        public virtual Veiculos Veiculos { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
