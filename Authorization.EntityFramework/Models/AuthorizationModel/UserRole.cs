using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Authorization.EntityFramework.Models.AuthorizationModel
{
    public class UserRole : IdentityUserRole<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
