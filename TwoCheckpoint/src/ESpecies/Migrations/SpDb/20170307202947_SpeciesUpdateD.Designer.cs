using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ESpecies.Data;

namespace ESpecies.Migrations.SpDb
{
    [DbContext(typeof(SpDbContext))]
    [Migration("20170307202947_SpeciesUpdateD")]
    partial class SpeciesUpdateD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ESpecies.Models.Carts", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amount");

                    b.Property<int>("EntityId");

                    b.HasKey("ApplicationUserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ESpecies.Models.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amount");

                    b.Property<int>("ApplicationUserId");

                    b.Property<string>("EntityID");

                    b.HasKey("Id");

                    b.ToTable("Donation");
                });

            modelBuilder.Entity("ESpecies.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComName");

                    b.Property<string>("CountryId");

                    b.Property<string>("Description");

                    b.Property<int>("EntityId");

                    b.Property<DateTime>("ListingDate");

                    b.Property<string>("PopAbbrev");

                    b.Property<string>("PopDesc");

                    b.Property<string>("SciName");

                    b.Property<string>("SpCode");

                    b.Property<int>("StatusId");

                    b.Property<string>("TSN");

                    b.Property<string>("VipCode");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });
        }
    }
}
