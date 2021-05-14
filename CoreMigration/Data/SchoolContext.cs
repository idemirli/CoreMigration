using CoreMigration.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMigration.Data
{
    public class SchoolContext : DbContext
    {

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lesson> Lessons { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=movies.db");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Teacher>().Property(b => b.Name).HasMaxLength(500);

            modelBuilder.Entity<Student>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Student>().Property(b => b.Name).HasMaxLength(50);


            modelBuilder.Entity<Department>().Property(b => b.Name).IsRequired();

            modelBuilder.Entity<User>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<User>().Property(b => b.Name).HasMaxLength(50);
            //modelBuilder.HasSequence<int>("Department_seq", schema: "dbo")
            // .StartsAt(0)
            // .IncrementsBy(1);

            //modelBuilder.Entity<Department>()
            //    .Property(o => o.Id)
            //    .HasDefaultValueSql("NEXT VALUE FOR dbo.Department_seq");

        }

    }
}
