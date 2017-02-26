using ESpecies.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ESpecies.Data
{
    public class SpDbContext : DbContext 

    {   public SpDbContext() { }

        public SpDbContext(DbContextOptions<SpDbContext> options)
        : base(options)
    {
            Database.EnsureCreated();
    }
        public DbSet<Species> Species { get; set; }
        public DbSet<Donation> Donation { get; set; }
    }
}
