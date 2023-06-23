using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CarZone.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Digite o login")]
        public string AcessoLogin { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
