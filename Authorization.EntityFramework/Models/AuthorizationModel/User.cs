using Microsoft.AspNetCore.Identity;

namespace Authorization.EntityFramework.Models.AuthorizationModel
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public int Age { get; set; }
    }
}
