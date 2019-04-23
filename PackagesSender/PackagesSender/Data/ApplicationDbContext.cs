using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1PackagesSender.Models;

namespace Task1PackagesSender.Data
{
    public class ApplicationDbContext : DbContext
    {


        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<MainPackage> MainPackages { get; set; }
      


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainPackage>().ToTable("MainPackages");
            modelBuilder.Entity<Delivery>().ToTable("Deliveries");
          

            base.OnModelCreating(modelBuilder);
        }



       

    }
}
