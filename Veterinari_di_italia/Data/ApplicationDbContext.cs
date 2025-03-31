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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>().HasOne(ur => ur.ApplicationUser).WithMany(ur => ur.ApplicationUserRoles).HasForeignKey(ur => ur.UserId);

            builder.Entity<ApplicationUserRole>().HasOne(ur => ur.ApplicationRole).WithMany(ur => ur.UserRole).HasForeignKey(ur => ur.RoleId);


            builder.Entity<AnagraficaAnimale>().HasOne(pd => pd.Tipo).WithMany(pd => pd.AnagraficaAnimale);

            builder.Entity<TipologiaAnimale>().HasMany(pd => pd.AnagraficaAnimale).WithOne(pd => pd.Tipo);


            builder.Entity<AnagraficaAnimale>().HasMany(cp => cp.visiteVeterinaries).WithOne(cp => cp.AnagraficaAnimale);

            builder.Entity<VisiteVeterinarie>().HasOne(cp => cp.AnagraficaAnimale).WithMany(cp => cp.visiteVeterinaries);


            builder.Entity<AnagraficaAnimale>().HasOne(dc => dc.ProprietarioAnimale).WithMany(dc => dc.AnagraficaAnimale);
            builder.Entity<ApplicationUser>().HasMany(dc => dc.AnagraficaAnimale).WithOne(dc => dc.ProprietarioAnimale);

            builder.Entity<AnagraficaAnimale>().HasMany(ln => ln.gestioneRicoveris).WithOne(ln => ln.AnagraficaAnimale);
            builder.Entity<GestioneRicoveri>().HasOne(ln => ln.AnagraficaAnimale).WithMany(ln => ln.gestioneRicoveris);

            builder.Entity<ApplicationUser>().HasMany(fi => fi.VenditaFarmaco).WithOne(fi => fi.Acquirente);
            builder.Entity<VenditaFarmaco>().HasMany(fi => fi.Farmacia).WithMany(fi => fi.VenditaFarmaco);
            builder.Entity<Farmacia>().HasMany(fi => fi.VenditaFarmaco).WithMany(fi => fi.Farmacia);
        }


    }


}
