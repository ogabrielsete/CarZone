using CarZone.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarZone.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail do usuário não é válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

    }
}
