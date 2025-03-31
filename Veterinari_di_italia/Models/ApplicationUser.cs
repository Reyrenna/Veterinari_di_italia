using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Veterinari_di_italia.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string CodiceFiscale { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public ICollection<AnagraficaAnimale> AnagraficaAnimale { get;set; }

        public ICollection<VenditaFarmaco> VenditaFarmaco { get; set; }

    }
}
