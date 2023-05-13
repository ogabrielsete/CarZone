namespace CarZone.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public string NomePagamento { get; set; }
        public string CategoriaVeiculo { get; set; }
        public int Meses { get; set; }
    }
}
