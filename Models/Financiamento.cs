namespace CarZone.Models
{
    public class Financiamento
    {
        public int FinanciamentoId { get; set; }
        public string NomeFinanciamento { get; set; }
        public string CategoriaVeiculo { get; set; }
        public int Meses { get; set; }
    }
}
