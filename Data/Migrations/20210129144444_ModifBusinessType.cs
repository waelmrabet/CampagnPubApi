using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ModifBusinessType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompagnBusinesses_Businesses_BusinessId",
                table: "CompagnBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Towns_Region_RegionId",
                table: "Towns");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "Regions");

            migrationBuilder.AddColumn<float>(
                name: "BudgetPrevisionnel",
                table: "Compagns",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Compagns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Objectif",
                table: "Compagns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PenetraionRate",
                table: "Compagns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Compagns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeId",
                table: "CompagnBusinesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "businessTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businessTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compagns_RegionId",
                table: "Compagns",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompagnBusinesses_BusinessTypeId",
                table: "CompagnBusinesses",
                column: "BusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompagnBusinesses_businessTypes_BusinessTypeId",
                table: "CompagnBusinesses",
                column: "BusinessTypeId",
                principalTable: "businessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compagns_Regions_RegionId",
                table: "Compagns",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Towns_Regions_RegionId",
                table: "Towns",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompagnBusinesses_businessTypes_BusinessTypeId",
                table: "CompagnBusinesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Compagns_Regions_RegionId",
                table: "Compagns");

            migrationBuilder.DropForeignKey(
                name: "FK_Towns_Regions_RegionId",
                table: "Towns");

            migrationBuilder.DropTable(
                name: "businessTypes");

            migrationBuilder.DropIndex(
                name: "IX_Compagns_RegionId",
                table: "Compagns");

            migrationBuilder.DropIndex(
                name: "IX_CompagnBusinesses_BusinessTypeId",
                table: "CompagnBusinesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "BudgetPrevisionnel",
                table: "Compagns");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Compagns");

            migrationBuilder.DropColumn(
                name: "Objectif",
                table: "Compagns");

            migrationBuilder.DropColumn(
                name: "PenetraionRate",
                table: "Compagns");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Compagns");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "CompagnBusinesses");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Region");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CompagnBusinesses_Businesses_BusinessId",
                table: "CompagnBusinesses",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Towns_Region_RegionId",
                table: "Towns",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
