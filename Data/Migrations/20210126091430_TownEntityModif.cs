using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TownEntityModif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Towns_Country_CountryId",
                table: "Towns");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Towns_CountryId",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Towns");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Towns",
                newName: "Region");

            migrationBuilder.AddColumn<string>(
                name: "Borough",
                table: "Towns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Canton",
                table: "Towns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Towns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departement",
                table: "Towns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Lat",
                table: "Towns",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Lng",
                table: "Towns",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borough",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "Canton",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "Departement",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Towns");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Towns",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Towns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Towns_CountryId",
                table: "Towns",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Towns_Country_CountryId",
                table: "Towns",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
