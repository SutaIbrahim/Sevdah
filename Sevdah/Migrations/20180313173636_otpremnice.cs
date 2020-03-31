using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sevdah.Migrations
{
    public partial class otpremnice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Otpremnica",
                columns: table => new
                {
                    OtpremnicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    KupacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otpremnica", x => x.OtpremnicaID);
                    table.ForeignKey(
                        name: "FK_Otpremnica_Kupci_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpremnicaProizvod",
                columns: table => new
                {
                    OtpremnicaProizvodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KolicinaKG = table.Column<float>(nullable: false),
                    OtpremnicaID = table.Column<int>(nullable: false),
                    ProizvodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpremnicaProizvod", x => x.OtpremnicaProizvodID);
                    table.ForeignKey(
                        name: "FK_OtpremnicaProizvod_Otpremnica_OtpremnicaID",
                        column: x => x.OtpremnicaID,
                        principalTable: "Otpremnica",
                        principalColumn: "OtpremnicaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtpremnicaProizvod_Proizvodi_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvodi",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Otpremnica_KupacID",
                table: "Otpremnica",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_OtpremnicaProizvod_OtpremnicaID",
                table: "OtpremnicaProizvod",
                column: "OtpremnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_OtpremnicaProizvod_ProizvodID",
                table: "OtpremnicaProizvod",
                column: "ProizvodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtpremnicaProizvod");

            migrationBuilder.DropTable(
                name: "Otpremnica");
        }
    }
}
