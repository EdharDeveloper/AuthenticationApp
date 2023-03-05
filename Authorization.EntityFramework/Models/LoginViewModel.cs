using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Authorization.EntityFramework.Models
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
