using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animals.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Vaccines");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PetVaccines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "PetVaccines");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Vaccines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
