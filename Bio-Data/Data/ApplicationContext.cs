using Bio_Data.Models;
using Bio_Data.Models.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bio_Data.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

       // public DbSet<User> Users { get; set; }
        public DbSet<User1> Users1 { get; set; }
        public DbSet<Personaldetails> personaldetails { get; set; }
        public DbSet<Familydetails> familydetails { get; set; }
        public DbSet<Contactdetails> contactdetails { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User { Id = 1, Usernmae = "Admin", Email = "admin@gmail.com", Password = "admin123", role = "Admin" }
        //        );
        //}
    }
}
