using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sevdah.Migrations
{
    public partial class IzmjenaRacunaDobavljaca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RacunProizvodDobavljaca_Dobavljaci_DobavljacID",
                table: "RacunProizvodDobavljaca");

            migrationBuilder.DropIndex(
                name: "IX_RacunProizvodDobavljaca_DobavljacID",
                table: "RacunProizvodDobavljaca");

            migrationBuilder.DropColumn(
                name: "DobavljacID",
                table: "RacunProizvodDobavljaca");

            migrationBuilder.AddColumn<int>(
                name: "DobavljacID",
                table: "RacuniDobavljaca",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RacunProizvodDobavljaca_VrstaProizvodaID",
                table: "RacunProizvodDobavljaca",
                column: "VrstaProizvodaID");

            migrationBuilder.CreateIndex(
                name: "IX_RacuniDobavljaca_DobavljacID",
                table: "RacuniDobavljaca",
                column: "DobavljacID");

            migrationBuilder.AddForeignKey(
                name: "FK_RacuniDobavljaca_Dobavljaci_DobavljacID",
                table: "RacuniDobavljaca",
                column: "DobavljacID",
                principalTable: "Dobavljaci",
                principalColumn: "DobavljacID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RacunProizvodDobavljaca_VrsteProizvoda_VrstaProizvodaID",
                table: "RacunProizvodDobavljaca",
                column: "VrstaProizvodaID",
                principalTable: "VrsteProizvoda",
                principalColumn: "VrstaProizvodaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RacuniDobavljaca_Dobavljaci_DobavljacID",
                table: "RacuniDobavljaca");

            migrationBuilder.DropForeignKey(
                name: "FK_RacunProizvodDobavljaca_VrsteProizvoda_VrstaProizvodaID",
                table: "RacunProizvodDobavljaca");

            migrationBuilder.DropIndex(
                name: "IX_RacunProizvodDobavljaca_VrstaProizvodaID",
                table: "RacunProizvodDobavljaca");

            migrationBuilder.DropIndex(
                name: "IX_RacuniDobavljaca_DobavljacID",
                table: "RacuniDobavljaca");

            migrationBuilder.DropColumn(
                name: "DobavljacID",
                table: "RacuniDobavljaca");

            migrationBuilder.AddColumn<int>(
                name: "DobavljacID",
                table: "RacunProizvodDobavljaca",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RacunProizvodDobavljaca_DobavljacID",
                table: "RacunProizvodDobavljaca",
                column: "DobavljacID");

            migrationBuilder.AddForeignKey(
                name: "FK_RacunProizvodDobavljaca_Dobavljaci_DobavljacID",
                table: "RacunProizvodDobavljaca",
                column: "DobavljacID",
                principalTable: "Dobavljaci",
                principalColumn: "DobavljacID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
