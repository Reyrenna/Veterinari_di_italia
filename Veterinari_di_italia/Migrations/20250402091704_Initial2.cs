using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Veterinari_di_italia.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipologiaAnimales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAnimale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipologiaAnimales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenditaFarmaco",
                columns: table => new
                {
                    IdVendita = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroRicetta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAcquisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcquirenteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenditaFarmaco", x => x.IdVendita);
                    table.ForeignKey(
                        name: "FK_VenditaFarmaco_AspNetUsers_AcquirenteId",
                        column: x => x.AcquirenteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnagraficaAnimales",
                columns: table => new
                {
                    IdAnimale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRegistrazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TipologiaId = table.Column<int>(type: "int", nullable: false),
                    Colore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDiNascita = table.Column<DateOnly>(type: "date", nullable: false),
                    PresenzaMicrochip = table.Column<bool>(type: "bit", nullable: false),
                    NumeroMicroChip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProprietarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnagraficaAnimales", x => x.IdAnimale);
                    table.ForeignKey(
                        name: "FK_AnagraficaAnimales_AspNetUsers_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnagraficaAnimales_TipologiaAnimales_TipologiaId",
                        column: x => x.TipologiaId,
                        principalTable: "TipologiaAnimales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GestioneRicoveris",
                columns: table => new
                {
                    IdRicovero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRicovero = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ricoverato = table.Column<bool>(type: "bit", nullable: false),
                    DescrizioneAnimale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAnimale = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestioneRicoveris", x => x.IdRicovero);
                    table.ForeignKey(
                        name: "FK_GestioneRicoveris_AnagraficaAnimales_IdAnimale",
                        column: x => x.IdAnimale,
                        principalTable: "AnagraficaAnimales",
                        principalColumn: "IdAnimale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisiteVeterinaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDellaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsameObiettivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAnimale = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisiteVeterinaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisiteVeterinaries_AnagraficaAnimales_IdAnimale",
                        column: x => x.IdAnimale,
                        principalTable: "AnagraficaAnimales",
                        principalColumn: "IdAnimale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Farmacias",
                columns: table => new
                {
                    IdFarmaco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DittaFornitrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElencoUsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Farmaco = table.Column<bool>(type: "bit", nullable: false),
                    VisiteVeterinarieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmacias", x => x.IdFarmaco);
                    table.ForeignKey(
                        name: "FK_Farmacias_VisiteVeterinaries_VisiteVeterinarieId",
                        column: x => x.VisiteVeterinarieId,
                        principalTable: "VisiteVeterinaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FarmaciaVenditaFarmaco",
                columns: table => new
                {
                    FarmaciaVenditaFarmacoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmaciaIdFarmaco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenditaFarmacoIdVendita = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmaciaVenditaFarmaco", x => x.FarmaciaVenditaFarmacoId);
                    table.ForeignKey(
                        name: "FK_FarmaciaVenditaFarmaco_Farmacias_FarmaciaIdFarmaco",
                        column: x => x.FarmaciaIdFarmaco,
                        principalTable: "Farmacias",
                        principalColumn: "IdFarmaco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmaciaVenditaFarmaco_VenditaFarmaco_VenditaFarmacoIdVendita",
                        column: x => x.VenditaFarmacoIdVendita,
                        principalTable: "VenditaFarmaco",
                        principalColumn: "IdVendita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e2d5024-c38d-4c5f-b16c-a2b493ce42f5", "0e2d5024-c38d-4c5f-b16c-a2b493ce42f5", "Veterinario", "VETERINARIO" },
                    { "38313626-5989-42B6-A848-A4CD63C725C9", "38313626-5989-42B6-A848-A4CD63C725C9", "Admin", "ADMIN" },
                    { "c1cf954c-68de-4ec4-b4d9-04cdb1a7f7ca", "c1cf954c-68de-4ec4-b4d9-04cdb1a7f7ca", "User", "USER" },
                    { "c7ef7bd0-60ab-4652-8025-f4b217cfe45d", "c7ef7bd0-60ab-4652-8025-f4b217cfe45d", "Farmacista", "FARMACISTA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnagraficaAnimales_ProprietarioId",
                table: "AnagraficaAnimales",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnagraficaAnimales_TipologiaId",
                table: "AnagraficaAnimales",
                column: "TipologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Farmacias_VisiteVeterinarieId",
                table: "Farmacias",
                column: "VisiteVeterinarieId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmaciaVenditaFarmaco_FarmaciaIdFarmaco",
                table: "FarmaciaVenditaFarmaco",
                column: "FarmaciaIdFarmaco");

            migrationBuilder.CreateIndex(
                name: "IX_FarmaciaVenditaFarmaco_VenditaFarmacoIdVendita",
                table: "FarmaciaVenditaFarmaco",
                column: "VenditaFarmacoIdVendita");

            migrationBuilder.CreateIndex(
                name: "IX_GestioneRicoveris_IdAnimale",
                table: "GestioneRicoveris",
                column: "IdAnimale");

            migrationBuilder.CreateIndex(
                name: "IX_VenditaFarmaco_AcquirenteId",
                table: "VenditaFarmaco",
                column: "AcquirenteId");

            migrationBuilder.CreateIndex(
                name: "IX_VisiteVeterinaries_IdAnimale",
                table: "VisiteVeterinaries",
                column: "IdAnimale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FarmaciaVenditaFarmaco");

            migrationBuilder.DropTable(
                name: "GestioneRicoveris");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Farmacias");

            migrationBuilder.DropTable(
                name: "VenditaFarmaco");

            migrationBuilder.DropTable(
                name: "VisiteVeterinaries");

            migrationBuilder.DropTable(
                name: "AnagraficaAnimales");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TipologiaAnimales");
        }
    }
}
