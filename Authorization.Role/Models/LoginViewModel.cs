using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Authorization.Role.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        public string ReturnUrl { get; set; }

    }
}
