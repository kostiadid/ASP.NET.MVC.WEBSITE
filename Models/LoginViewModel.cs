using System.ComponentModel.DataAnnotations;

namespace MyAspNetApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }
        [Required]
        [UIHint("Password")]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required]
        [Display(Name = "Remember me ?")]
        public bool RememberMe { get; set; } 
    }
}