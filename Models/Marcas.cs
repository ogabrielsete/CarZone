namespace CarZone.Models
{
    public class Marcas
    {
        public int MarcaId { get; set; }
        public string MarcaNome { get; set; }


        public virtual Veiculos Veiculo { get; set; }
        public virtual ModeloVeiculos ModeloVeiculo{ get; set; }
    }
}
