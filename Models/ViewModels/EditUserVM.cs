using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CarZone.Models.ViewModels
{
    public class EditUserVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }


        // 

        [Display(Name = "Função")]
        public string Role { get; set; }
        public List<SelectListItem> AvailableRoles { get; set; }
    }
}
