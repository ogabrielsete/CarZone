using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarZone.Models.ViewModels
{
    public class VendasVM
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public int PagamentoId { get; set; }
        public string Pagamento { get; set; }
        public int ModeloId { get; set; }
        public string Modelo { get; set; }
    }
}
