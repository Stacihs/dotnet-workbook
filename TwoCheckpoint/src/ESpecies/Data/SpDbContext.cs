using ESpecies.Models;
using Microsoft.EntityFrameworkCore;

namespace ESpecies.Data
{
    public class SpDbContext : DbContext
    {

        public SpDbContext() { }

        public SpDbContext(DbContextOptions<SpDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Species> Species { get; set; } //set to public to access
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Donation> Donation { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Species>().ToTable("Species");
        //}
    }
}