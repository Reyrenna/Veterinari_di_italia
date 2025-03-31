using Microsoft.AspNetCore.Identity;

namespace Veterinari_di_italia.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRole { get; set; }
    }
}
