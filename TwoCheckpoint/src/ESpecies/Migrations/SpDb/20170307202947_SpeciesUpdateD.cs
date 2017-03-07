using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESpecies.Migrations.SpDb
{
    public partial class SpeciesUpdateD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(nullable: true),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ApplicationUserId);
                });

            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PopAbbrev",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PopDesc",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpCode",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TSN",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VipCode",
                table: "Species",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "PopAbbrev",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "PopDesc",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SpCode",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "TSN",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "VipCode",
                table: "Species");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(nullable: true),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ApplicationUserId);
                });
        }
    }
}
