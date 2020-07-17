using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementABC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Student>()
               .HasOne<Class>(s => s.Class)
               .WithMany(g => g.students)
               .HasForeignKey(s => s.ClassId);
            modelBuilder.Entity<Class>().HasData(
                new Class()
                {
                    ClassId = 1,
                    ClassName = "C01"
                },
                new Class()
                {
                    ClassId = 2,
                    ClassName = "c02"
                },
                new Class()
                {
                    ClassId = 3,
                    ClassName = "C03"
                }
            );
        }
    }
}
