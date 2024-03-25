using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage="O nome do cliente é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        //[StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres.")]
        public string Endereco { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        //[StringLength(11, ErrorMessage = "O telefone deve ter no máximo 11 caracteres.")]
        public string Telefone { get; set; }

        public virtual List<Venda> Vendas { get; set; }
    }
}
