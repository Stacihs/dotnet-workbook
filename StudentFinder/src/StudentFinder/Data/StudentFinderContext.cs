using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentFinder.Models;

namespace StudentFinder.Data
{
    public class StudentFinderContext : DbContext
    {
        public StudentFinderContext()
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>()
        //        .HasMany(x => x.)
        //        .WithMany(x => x.Recipes)
        //    .Map(x =>
        //    {
        //        x.ToTable("Cookbooks"); // third table is named Cookbooks
        //x.MapLeftKey("RecipeId");
        //        x.MapRightKey("MemberId");
        //    });

            
        //}

        public StudentFinderContext(DbContextOptions<StudentFinderContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //public DbSet<CentralModel> Central { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Space> Space { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
