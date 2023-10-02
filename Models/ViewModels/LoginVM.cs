using System.ComponentModel.DataAnnotations;

namespace CarZone.Models.ViewModels
{
    public class LoginVM
    {

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

    }
}
