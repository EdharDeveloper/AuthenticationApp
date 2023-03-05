using Microsoft.AspNetCore.Identity;

namespace Authorization.EntityFramework.Models.AuthorizationModel
{
    public class Role : IdentityRole<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
