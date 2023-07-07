using System.ComponentModel.DataAnnotations;

namespace CarZone.Models
{
    public class RedefinirSenha
    {
        [Required(ErrorMessage = "Digite o login")]
        public string AcessoLogin { get; set; }

        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }

    }
}
