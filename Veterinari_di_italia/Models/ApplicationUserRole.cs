using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Veterinari_di_italia.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public required string UserId { get; set; }
        public required string RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(RoleId))]
        public ApplicationRole ApplicationRole { get; set; }
    }
}
