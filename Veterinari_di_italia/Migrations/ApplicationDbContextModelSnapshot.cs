﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veterinari_di_italia.Data;

#nullable disable

namespace Veterinari_di_italia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarmaciaVenditaFarmaco", b =>
                {
                    b.Property<Guid>("FarmaciaIdFarmaco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VenditaFarmacoIdVendita")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FarmaciaIdFarmaco", "VenditaFarmacoIdVendita");

                    b.HasIndex("VenditaFarmacoIdVendita");

                    b.ToTable("FarmaciaVenditaFarmaco");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.AnagraficaAnimale", b =>
                {
                    b.Property<Guid>("IdAnimale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Colore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DataDiNascita")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataRegistrazione")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("NumeroMicroChip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PresenzaMicrochip")
                        .HasColumnType("bit");

                    b.Property<string>("ProprietarioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TipologiaId")
                        .HasColumnType("int");

                    b.HasKey("IdAnimale");

                    b.HasIndex("ProprietarioId");

                    b.HasIndex("TipologiaId");

                    b.ToTable("AnagraficaAnimales");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "38313626-5989-42B6-A848-A4CD63C725C9",
                            ConcurrencyStamp = "38313626-5989-42B6-A848-A4CD63C725C9",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "0e2d5024-c38d-4c5f-b16c-a2b493ce42f5",
                            ConcurrencyStamp = "0e2d5024-c38d-4c5f-b16c-a2b493ce42f5",
                            Name = "Veterinario",
                            NormalizedName = "VETERINARIO"
                        },
                        new
                        {
                            Id = "c7ef7bd0-60ab-4652-8025-f4b217cfe45d",
                            ConcurrencyStamp = "c7ef7bd0-60ab-4652-8025-f4b217cfe45d",
                            Name = "Farmacista",
                            NormalizedName = "FARMACISTA"
                        },
                        new
                        {
                            Id = "c1cf954c-68de-4ec4-b4d9-04cdb1a7f7ca",
                            ConcurrencyStamp = "c1cf954c-68de-4ec4-b4d9-04cdb1a7f7ca",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CodiceFiscale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.Farmacia", b =>
                {
                    b.Property<Guid>("IdFarmaco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DittaFornitrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElencoUsi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VisiteVeterinarieId")
                        .HasColumnType("int");

                    b.HasKey("IdFarmaco");

                    b.HasIndex("VisiteVeterinarieId");

                    b.ToTable("Farmacias");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.GestioneRicoveri", b =>
                {
                    b.Property<int>("IdRicovero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRicovero"));

                    b.Property<DateTime>("DataRicovero")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescrizioneAnimale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdAnimale")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ricoverato")
                        .HasColumnType("bit");

                    b.HasKey("IdRicovero");

                    b.HasIndex("IdAnimale");

                    b.ToTable("GestioneRicoveris");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.TipologiaAnimale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TipoAnimale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipologiaAnimales");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.VenditaFarmaco", b =>
                {
                    b.Property<Guid>("IdVendita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcquirenteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataAcquisto")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroRicetta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVendita");

                    b.HasIndex("AcquirenteId");

                    b.ToTable("VenditaFarmaco");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.VisiteVeterinarie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AnagraficaAnimaleIdAnimale")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDellaVisita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EsameObiettivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnagraficaAnimaleIdAnimale");

                    b.ToTable("VisiteVeterinaries");
                });

            modelBuilder.Entity("FarmaciaVenditaFarmaco", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.Farmacia", null)
                        .WithMany()
                        .HasForeignKey("FarmaciaIdFarmaco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Veterinari_di_italia.Models.VenditaFarmaco", null)
                        .WithMany()
                        .HasForeignKey("VenditaFarmacoIdVendita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.AnagraficaAnimale", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.ApplicationUser", "ProprietarioAnimale")
                        .WithMany("AnagraficaAnimale")
                        .HasForeignKey("ProprietarioId");

                    b.HasOne("Veterinari_di_italia.Models.TipologiaAnimale", "Tipo")
                        .WithMany("AnagraficaAnimale")
                        .HasForeignKey("TipologiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProprietarioAnimale");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.ApplicationUserRole", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.ApplicationRole", "ApplicationRole")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Veterinari_di_italia.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationRole");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.Farmacia", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.VisiteVeterinarie", null)
                        .WithMany("Farmaci")
                        .HasForeignKey("VisiteVeterinarieId");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.GestioneRicoveri", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.AnagraficaAnimale", "AnagraficaAnimale")
                        .WithMany("gestioneRicoveris")
                        .HasForeignKey("IdAnimale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnagraficaAnimale");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.VenditaFarmaco", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.ApplicationUser", "Acquirente")
                        .WithMany("VenditaFarmaco")
                        .HasForeignKey("AcquirenteId");

                    b.Navigation("Acquirente");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.VisiteVeterinarie", b =>
                {
                    b.HasOne("Veterinari_di_italia.Models.AnagraficaAnimale", "AnagraficaAnimale")
                        .WithMany("visiteVeterinaries")
                        .HasForeignKey("AnagraficaAnimaleIdAnimale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnagraficaAnimale");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.AnagraficaAnimale", b =>
                {
                    b.Navigation("gestioneRicoveris");

                    b.Navigation("visiteVeterinaries");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.ApplicationRole", b =>
                {
                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.ApplicationUser", b =>
                {
                    b.Navigation("AnagraficaAnimale");

                    b.Navigation("ApplicationUserRoles");

                    b.Navigation("VenditaFarmaco");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.TipologiaAnimale", b =>
                {
                    b.Navigation("AnagraficaAnimale");
                });

            modelBuilder.Entity("Veterinari_di_italia.Models.VisiteVeterinarie", b =>
                {
                    b.Navigation("Farmaci");
                });
#pragma warning restore 612, 618
        }
    }
}
