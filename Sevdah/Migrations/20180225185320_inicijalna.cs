using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sevdah.Migrations
{
    public partial class inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "RacuniDobavljaca",
                columns: table => new
                {
                    RacunDobavljacaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojRacuna = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    DosadPlaceno = table.Column<double>(nullable: false),
                    Placeno = table.Column<bool>(nullable: false),
                    UkupnoBezPDV = table.Column<double>(nullable: false),
                    UkupnoSaPDV = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacuniDobavljaca", x => x.RacunDobavljacaID);
                });

            migrationBuilder.CreateTable(
                name: "Skladiste",
                columns: table => new
                {
                    SkladisteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KolicinaUKg = table.Column<float>(nullable: false),
                    VrstaKafe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladiste", x => x.SkladisteID);
                });

            migrationBuilder.CreateTable(
                name: "VrsteProizvoda",
                columns: table => new
                {
                    VrstaProizvodaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrsteProizvoda", x => x.VrstaProizvodaID);
                });

            migrationBuilder.CreateTable(
                name: "Dobavljaci",
                columns: table => new
                {
                    DobavljacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(maxLength: 100, nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    ID_broj = table.Column<string>(maxLength: 14, nullable: false),
                    Kredit = table.Column<double>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 100, nullable: false),
                    PDV_broj = table.Column<string>(maxLength: 13, nullable: false),
                    Telefon = table.Column<string>(maxLength: 100, nullable: true),
                    ZiroRacun = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobavljaci", x => x.DobavljacID);
                    table.ForeignKey(
                        name: "FK_Dobavljaci_Gradovi_GradID",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    KupacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(maxLength: 100, nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    ID_broj = table.Column<string>(maxLength: 14, nullable: false),
                    Kredit = table.Column<double>(nullable: true),
                    NazivKupca = table.Column<string>(maxLength: 100, nullable: false),
                    PDV_broj = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.KupacID);
                    table.ForeignKey(
                        name: "FK_Kupci_Gradovi_GradID",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    ProizvodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BarKod = table.Column<string>(nullable: true),
                    CijenaBezPDV = table.Column<double>(nullable: false),
                    CijenaSaPDV = table.Column<double>(nullable: false),
                    Masa = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    SkladisteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.ProizvodID);
                    table.ForeignKey(
                        name: "FK_Proizvodi_Skladiste_SkladisteID",
                        column: x => x.SkladisteID,
                        principalTable: "Skladiste",
                        principalColumn: "SkladisteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodDobavljac",
                columns: table => new
                {
                    ProizvodDobavljacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DobavljacID = table.Column<int>(nullable: false),
                    VrstaProizvodaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodDobavljac", x => x.ProizvodDobavljacID);
                    table.ForeignKey(
                        name: "FK_ProizvodDobavljac_Dobavljaci_DobavljacID",
                        column: x => x.DobavljacID,
                        principalTable: "Dobavljaci",
                        principalColumn: "DobavljacID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProizvodDobavljac_VrsteProizvoda_VrstaProizvodaID",
                        column: x => x.VrstaProizvodaID,
                        principalTable: "VrsteProizvoda",
                        principalColumn: "VrstaProizvodaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RacunProizvodDobavljaca",
                columns: table => new
                {
                    RacunProizvodDobavljacaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DobavljacID = table.Column<int>(nullable: false),
                    IznosBezPDV = table.Column<int>(nullable: false),
                    IznosSaPDV = table.Column<int>(nullable: false),
                    KolicinaUkomadima = table.Column<float>(nullable: false),
                    RacunDobavljacaID = table.Column<int>(nullable: false),
                    VrstaProizvodaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacunProizvodDobavljaca", x => x.RacunProizvodDobavljacaID);
                    table.ForeignKey(
                        name: "FK_RacunProizvodDobavljaca_Dobavljaci_DobavljacID",
                        column: x => x.DobavljacID,
                        principalTable: "Dobavljaci",
                        principalColumn: "DobavljacID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacunProizvodDobavljaca_RacuniDobavljaca_RacunDobavljacaID",
                        column: x => x.RacunDobavljacaID,
                        principalTable: "RacuniDobavljaca",
                        principalColumn: "RacunDobavljacaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UplateDobavljacu",
                columns: table => new
                {
                    UplataDobavljacuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    DobavljacID = table.Column<int>(nullable: false),
                    Iznos = table.Column<double>(nullable: false),
                    RacunDobavljacaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UplateDobavljacu", x => x.UplataDobavljacuID);
                    table.ForeignKey(
                        name: "FK_UplateDobavljacu_Dobavljaci_DobavljacID",
                        column: x => x.DobavljacID,
                        principalTable: "Dobavljaci",
                        principalColumn: "DobavljacID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UplateDobavljacu_RacuniDobavljaca_RacunDobavljacaID",
                        column: x => x.RacunDobavljacaID,
                        principalTable: "RacuniDobavljaca",
                        principalColumn: "RacunDobavljacaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Racuni",
                columns: table => new
                {
                    RacunID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojFiskalnogRacuna = table.Column<string>(nullable: true),
                    BrojRacuna = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    DosadPlaceno = table.Column<double>(nullable: false),
                    KupacID = table.Column<int>(nullable: false),
                    PDV = table.Column<float>(nullable: false),
                    Placeno = table.Column<bool>(nullable: false),
                    UkupnoBezPDV = table.Column<double>(nullable: false),
                    UkupnoZaNaplatu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racuni", x => x.RacunID);
                    table.ForeignKey(
                        name: "FK_Racuni_Kupci_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    UplataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<double>(nullable: false),
                    KupacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.UplataID);
                    table.ForeignKey(
                        name: "FK_Uplate_Kupci_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdobreniRabat",
                columns: table => new
                {
                    OdobreniRabatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IznosPostotci = table.Column<float>(nullable: false),
                    KupacID = table.Column<int>(nullable: false),
                    ProizvodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdobreniRabat", x => x.OdobreniRabatID);
                    table.ForeignKey(
                        name: "FK_OdobreniRabat_Kupci_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdobreniRabat_Proizvodi_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvodi",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RacunProizvodi",
                columns: table => new
                {
                    RacunProizvodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CijenaBezPDV = table.Column<double>(nullable: false),
                    IznosBezPDV = table.Column<double>(nullable: false),
                    IznosRabata = table.Column<double>(nullable: false),
                    KolicinaKG = table.Column<float>(nullable: false),
                    ProizvodID = table.Column<int>(nullable: false),
                    Rabat = table.Column<float>(nullable: false),
                    RacunID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacunProizvodi", x => x.RacunProizvodID);
                    table.ForeignKey(
                        name: "FK_RacunProizvodi_Proizvodi_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvodi",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacunProizvodi_Racuni_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racuni",
                        principalColumn: "RacunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dobavljaci_GradID",
                table: "Dobavljaci",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupci_GradID",
                table: "Kupci",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_OdobreniRabat_KupacID",
                table: "OdobreniRabat",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_OdobreniRabat_ProizvodID",
                table: "OdobreniRabat",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodDobavljac_DobavljacID",
                table: "ProizvodDobavljac",
                column: "DobavljacID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodDobavljac_VrstaProizvodaID",
                table: "ProizvodDobavljac",
                column: "VrstaProizvodaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_SkladisteID",
                table: "Proizvodi",
                column: "SkladisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Racuni_KupacID",
                table: "Racuni",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_RacunProizvodDobavljaca_DobavljacID",
                table: "RacunProizvodDobavljaca",
                column: "DobavljacID");

            migrationBuilder.CreateIndex(
                name: "IX_RacunProizvodDobavljaca_RacunDobavljacaID",
                table: "RacunProizvodDobavljaca",
                column: "RacunDobavljacaID");

            migrationBuilder.CreateIndex(
                name: "IX_RacunProizvodi_ProizvodID",
                table: "RacunProizvodi",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_RacunProizvodi_RacunID",
                table: "RacunProizvodi",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate_KupacID",
                table: "Uplate",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_UplateDobavljacu_DobavljacID",
                table: "UplateDobavljacu",
                column: "DobavljacID");

            migrationBuilder.CreateIndex(
                name: "IX_UplateDobavljacu_RacunDobavljacaID",
                table: "UplateDobavljacu",
                column: "RacunDobavljacaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdobreniRabat");

            migrationBuilder.DropTable(
                name: "ProizvodDobavljac");

            migrationBuilder.DropTable(
                name: "RacunProizvodDobavljaca");

            migrationBuilder.DropTable(
                name: "RacunProizvodi");

            migrationBuilder.DropTable(
                name: "Uplate");

            migrationBuilder.DropTable(
                name: "UplateDobavljacu");

            migrationBuilder.DropTable(
                name: "VrsteProizvoda");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Racuni");

            migrationBuilder.DropTable(
                name: "Dobavljaci");

            migrationBuilder.DropTable(
                name: "RacuniDobavljaca");

            migrationBuilder.DropTable(
                name: "Skladiste");

            migrationBuilder.DropTable(
                name: "Kupci");

            migrationBuilder.DropTable(
                name: "Gradovi");
        }
    }
}
