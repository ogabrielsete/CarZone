namespace CarZone.Models
{
    public class VeiculoModel
    {
        public int Id { get; set; }

        // colocar modelo que é uma fk

        public int Placa { get; set; }

        public int Ano { get; set; }

        public bool StatusVenda { get; set; }
    }
}
