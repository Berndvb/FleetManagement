using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManager.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentiteitPersoon",
                columns: table => new
                {
                    Rijksregisternummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentiteitPersoon", x => x.Rijksregisternummer);
                });

            migrationBuilder.CreateTable(
                name: "IdentiteitVoertuig",
                columns: table => new
                {
                    Chassisnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandstofType = table.Column<int>(type: "int", nullable: false),
                    WagenType = table.Column<int>(type: "int", nullable: false),
                    Merk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nummerplaten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentiteitVoertuig", x => x.Chassisnummer);
                });

            migrationBuilder.CreateTable(
                name: "TankkaartOpties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandstofType = table.Column<int>(type: "int", nullable: false),
                    ExtraServices = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankkaartOpties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verzekeringsmaatschappijen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Verzekeringsmaatschappijen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verzekeringsmaatschappijen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contactgegevens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmailAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GsmNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefoonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactgegevens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contactgegevens_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voertuigen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentiteitChassisnummer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Kilometerstanden = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuigen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voertuigen_IdentiteitVoertuig_IdentiteitChassisnummer",
                        column: x => x.IdentiteitChassisnummer,
                        principalTable: "IdentiteitVoertuig",
                        principalColumn: "Chassisnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tankkaarten",
                columns: table => new
                {
                    Kaartnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GeldigheidsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthenticatieType = table.Column<int>(type: "int", nullable: false),
                    TankkaartOptiesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Geblokkeerd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tankkaarten", x => x.Kaartnummer);
                    table.ForeignKey(
                        name: "FK_Tankkaarten_TankkaartOpties_TankkaartOptiesId",
                        column: x => x.TankkaartOptiesId,
                        principalTable: "TankkaartOpties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentiteitRijksregisternummer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContactgegevensId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RijbewijsType = table.Column<int>(type: "int", nullable: false),
                    Indienst = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chauffeurs_Contactgegevens_ContactgegevensId",
                        column: x => x.ContactgegevensId,
                        principalTable: "Contactgegevens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chauffeurs_IdentiteitPersoon_IdentiteitRijksregisternummer",
                        column: x => x.IdentiteitRijksregisternummer,
                        principalTable: "IdentiteitPersoon",
                        principalColumn: "Rijksregisternummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactgegevensId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Ondernemingsnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bankrekeningnummer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garage_Contactgegevens_ContactgegevensId",
                        column: x => x.ContactgegevensId,
                        principalTable: "Contactgegevens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aanvragen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AanmaakDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AanvraagType = table.Column<int>(type: "int", nullable: false),
                    EersteDatumInplanning = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TweedeDatumInplanning = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    VoertuigId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChauffeurId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanvragen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aanvragen_Chauffeurs_ChauffeurId",
                        column: x => x.ChauffeurId,
                        principalTable: "Chauffeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aanvragen_Voertuigen_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChauffeurVoertuig",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TankkaartKaartnummer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChauffeurId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Actief = table.Column<bool>(type: "bit", nullable: false),
                    AanmaakDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AfsluitDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReadVoertuigId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChauffeurVoertuig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChauffeurVoertuig_Chauffeurs_ChauffeurId",
                        column: x => x.ChauffeurId,
                        principalTable: "Chauffeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChauffeurVoertuig_Tankkaarten_TankkaartKaartnummer",
                        column: x => x.TankkaartKaartnummer,
                        principalTable: "Tankkaarten",
                        principalColumn: "Kaartnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChauffeurVoertuig_Voertuigen_ReadVoertuigId",
                        column: x => x.ReadVoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TankkaartChauffeur",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TankkaartKaartnummer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChauffeurId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Actief = table.Column<bool>(type: "bit", nullable: false),
                    AanmaakDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AfsluitDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankkaartChauffeur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TankkaartChauffeur_Chauffeurs_ChauffeurId",
                        column: x => x.ChauffeurId,
                        principalTable: "Chauffeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TankkaartChauffeur_Tankkaarten_TankkaartKaartnummer",
                        column: x => x.TankkaartKaartnummer,
                        principalTable: "Tankkaarten",
                        principalColumn: "Kaartnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administratie",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UitvoeringsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacturatieDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prijs = table.Column<float>(type: "real", nullable: false),
                    GarageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumVoorval = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchadeOmschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerzekeringsMaatschappij = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferentieNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HerstellingStatus = table.Column<int>(type: "int", nullable: true),
                    VoertuigId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReadOnderhoudsbeurt_VoertuigId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administratie_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administratie_Voertuigen_ReadOnderhoudsbeurt_VoertuigId",
                        column: x => x.ReadOnderhoudsbeurt_VoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administratie_Voertuigen_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AdministratieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Administratie_AdministratieId",
                        column: x => x.AdministratieId,
                        principalTable: "Administratie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aanvragen_ChauffeurId",
                table: "Aanvragen",
                column: "ChauffeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanvragen_VoertuigId",
                table: "Aanvragen",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Administratie_GarageId",
                table: "Administratie",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Administratie_ReadOnderhoudsbeurt_VoertuigId",
                table: "Administratie",
                column: "ReadOnderhoudsbeurt_VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Administratie_VoertuigId",
                table: "Administratie",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_ContactgegevensId",
                table: "Chauffeurs",
                column: "ContactgegevensId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_IdentiteitRijksregisternummer",
                table: "Chauffeurs",
                column: "IdentiteitRijksregisternummer");

            migrationBuilder.CreateIndex(
                name: "IX_ChauffeurVoertuig_ChauffeurId",
                table: "ChauffeurVoertuig",
                column: "ChauffeurId");

            migrationBuilder.CreateIndex(
                name: "IX_ChauffeurVoertuig_ReadVoertuigId",
                table: "ChauffeurVoertuig",
                column: "ReadVoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_ChauffeurVoertuig_TankkaartKaartnummer",
                table: "ChauffeurVoertuig",
                column: "TankkaartKaartnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Contactgegevens_AdresId",
                table: "Contactgegevens",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_File_AdministratieId",
                table: "File",
                column: "AdministratieId");

            migrationBuilder.CreateIndex(
                name: "IX_Garage_ContactgegevensId",
                table: "Garage",
                column: "ContactgegevensId");

            migrationBuilder.CreateIndex(
                name: "IX_TankkaartChauffeur_ChauffeurId",
                table: "TankkaartChauffeur",
                column: "ChauffeurId");

            migrationBuilder.CreateIndex(
                name: "IX_TankkaartChauffeur_TankkaartKaartnummer",
                table: "TankkaartChauffeur",
                column: "TankkaartKaartnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Tankkaarten_TankkaartOptiesId",
                table: "Tankkaarten",
                column: "TankkaartOptiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigen_IdentiteitChassisnummer",
                table: "Voertuigen",
                column: "IdentiteitChassisnummer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aanvragen");

            migrationBuilder.DropTable(
                name: "ChauffeurVoertuig");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "TankkaartChauffeur");

            migrationBuilder.DropTable(
                name: "Verzekeringsmaatschappijen");

            migrationBuilder.DropTable(
                name: "Administratie");

            migrationBuilder.DropTable(
                name: "Chauffeurs");

            migrationBuilder.DropTable(
                name: "Tankkaarten");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "Voertuigen");

            migrationBuilder.DropTable(
                name: "IdentiteitPersoon");

            migrationBuilder.DropTable(
                name: "TankkaartOpties");

            migrationBuilder.DropTable(
                name: "Contactgegevens");

            migrationBuilder.DropTable(
                name: "IdentiteitVoertuig");

            migrationBuilder.DropTable(
                name: "Adres");
        }
    }
}
