using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SingularityLimitedPhaseOneTest;

namespace SingularityLimitedPhaseOneTest.Data
{
    public class SingularityLimitedPhaseOneTestContext : DbContext
    {
        public SingularityLimitedPhaseOneTestContext(DbContextOptions<SingularityLimitedPhaseOneTestContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
            .HasData(
                new Product { Id = 1, Name = "Product 101" ,Description= "Product 101 des", SKU="#001", Price=10},
                new Product { Id = 2, Name = "Product 103", Description = "Product 102 des", SKU = "#002", Price = 20 },
                new Product { Id = 3, Name = "Product 102", Description = "Product 103 des", SKU = "#003", Price = 30 }
            );
        }

    }
}
