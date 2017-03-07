using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESpecies.Migrations.SpDb
{
    public partial class SpeciesUpdateC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
