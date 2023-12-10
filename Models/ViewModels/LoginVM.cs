using System.ComponentModel.DataAnnotations;

namespace CarZone.Models.ViewModels
{
    public class LoginVM
    {

        [Required(ErrorMessage = "O usuário é obrigatório")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
    ErrorMessage = "A senha necessita ter número, caractere especial e letra maiúscula.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "O email não é um e-mail válido.")]
        [Required(ErrorMessage = "O email é obrigatório.")] 
        public string Email { get; set; }


    }
}
