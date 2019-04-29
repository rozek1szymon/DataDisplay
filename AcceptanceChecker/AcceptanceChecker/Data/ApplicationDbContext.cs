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
        
        public DbSet<AcceptingPerson> AcceptingPeople { get; set; }
        public DbSet<Employees> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            

        }

    }
}
