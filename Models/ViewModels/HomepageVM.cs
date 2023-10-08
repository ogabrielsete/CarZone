namespace CarZone.Models.ViewModels
{
    public class HomepageVM
    {
        public Cliente Cliente { get; set; }
        public Venda Venda { get; set; }
        public Veiculo Veiculo { get; set; }


        public int TotalClientes { get; set; }
        public int TotalVeiculos { get; set; }
        public int TotalVendas { get; set; }
    }
}
