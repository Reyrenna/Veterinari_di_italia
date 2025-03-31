using Microsoft.AspNetCore.Identity;

namespace Veterinari_di_italia.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUser ApplicationUser { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }
}
