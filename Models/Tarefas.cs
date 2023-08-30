using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarZone.Models
{
    [Table("Tarefas")]
    public class Tarefas
    {
        public int Id { get; set; }

        [Display(Name = "Descricao")]
        [Required]
        public string Descricao { get; set; }

        [Display(Name = "Concluido")]
        public bool Concluido { get; set; }

        [Display(Name = "Usuario")]
        public int UserId { get; set; }
        //public Usuario Usuario { get; set; }
    }
}
