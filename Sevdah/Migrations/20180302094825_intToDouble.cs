using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sevdah.Migrations
{
    public partial class intToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "IznosSaPDV",
                table: "RacunProizvodDobavljaca",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "IznosBezPDV",
                table: "RacunProizvodDobavljaca",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IznosSaPDV",
                table: "RacunProizvodDobavljaca",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "IznosBezPDV",
                table: "RacunProizvodDobavljaca",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
