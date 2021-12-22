using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<Education> Educations{ get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<University> Universities{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Education>().HasOne(fk => fk.University).WithMany(k => k.Education); //many to one
            modelBuilder.Entity<Profiling>().HasOne(fk => fk.Education).WithMany(k => k.Profiling); //many to one*/

           /* modelBuilder.Entity<Employee>().HasOne(fk => fk.Account.NIK);*/
             /*
            modelBuilder.Entity<Profiling>().HasOne(fk => fk.Account).WithOne(fk => fk.Profiling);*/
           /* modelBuilder.Entity<University>().HasMany(pk => pk.Educations).WithOne(fk => fk.University); //one to many */
        }
    }
}
