using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESpecies.Data.Migrations
{
    public partial class ApplicationDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComName = table.Column<string>(nullable: true),
                    CountryId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EntityId = table.Column<int>(nullable: false),
                    ListingDate = table.Column<int>(nullable: false),
                    PopAbbrev = table.Column<string>(nullable: true),
                    PopDesc = table.Column<string>(nullable: true),
                    SciName = table.Column<string>(nullable: true),
                    SpCode = table.Column<string>(nullable: true),
                    SponsorId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    TSN = table.Column<string>(nullable: true),
                    VipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    EntityID = table.Column<string>(nullable: true),
                    SpeciesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donation_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    DonationId = table.Column<int>(nullable: true),
                    EntityId = table.Column<string>(nullable: true),
                    SpeciesId = table.Column<int>(nullable: true),
                    SponsorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Donation_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "DonationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonationId",
                table: "AspNetUsers",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpeciesId",
                table: "AspNetUsers",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_DonationId",
                table: "Cart",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_SpeciesId",
                table: "Cart",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_SpeciesId",
                table: "Donation",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Donation_DonationId",
                table: "AspNetUsers",
                column: "DonationId",
                principalTable: "Donation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Species_SpeciesId",
                table: "AspNetUsers",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Donation_DonationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Species_SpeciesId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DonationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SpeciesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DonationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Donation");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
