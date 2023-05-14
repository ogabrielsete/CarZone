namespace CarZone.Models
{
    public class ModeloVeiculos
    {
        public int Id { get; set; }
        public string NomeModelo { get; set; }


        public List<Marcas> Marca { get; set; }
    }
}
