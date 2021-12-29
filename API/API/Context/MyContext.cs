using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Proxies;
namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<Education> Educations{ get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<University> Universities{ get; set; }
        public DbSet<Role> Rules{ get; set; }
        public DbSet<AccountRole> AccountRules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>().HasOne(fk => fk.University).WithMany(k => k.Education); //many to one
            modelBuilder.Entity<Profiling>().HasOne(fk => fk.Education).WithMany(k => k.Profiling); //many to one
            modelBuilder.Entity<Employee>().HasOne(f => f.Account).WithOne(fk => fk.Employee);
            modelBuilder.Entity<Account>().HasOne(f => f.Profiling).WithOne(fk => fk.Account);
 
        }
    }
}
