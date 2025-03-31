using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Veterinari_di_italia.Models;


namespace Veterinari_di_italia.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string,IdentityUserClaim<string>,ApplicationUserRole,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AnagraficaAnimale> AnagraficaAnimales { get; set; }
        public DbSet<Farmacia> Farmacias { get; set; }
        public DbSet<GestioneRicoveri> GestioneRicoveris { get; set; }
        public DbSet<TipologiaAnimale> TipologiaAnimales { get;set; }

        public DbSet<VenditaFarmaco> VenditaFarmaco { get; set; }

        public DbSet<VisiteVeterinarie> VisiteVeterinaries { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        

        
    }


}
