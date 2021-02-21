using SingularityLimitedPhaseOneTest.Data;
using SingularityLimitedPhaseOneTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingularityLimitedPhaseOneTest
{
    public class Seed
    {

            public static void SeedData(SingularityLimitedPhaseOneTestContext context)
            {
                if (!context.Product.Any())
                {
                    var products = new List<Product>{
                    new Product
                    {
                        Id = 1, Name = "Product 101" ,Description= "Product 101 des", SKU="#001", Price=10
                    },
                    new Product
                    {
                       Id = 2, Name = "Product 102" ,Description= "Product 102 des", SKU="#002", Price=20
                    },
                    new Product
                    {
                        Id = 3, Name = "Product 103" ,Description= "Product 103 des", SKU="#003", Price=30
                    },
                    new Product
                    {
                        Id = 4, Name = "Product 104" ,Description= "Product 104 des", SKU="#004", Price=40
                    },
                    new Product
                    {
                        Id = 5, Name = "Product 105" ,Description= "Product 105 des", SKU="#005", Price=50
                    }
                };

                    context.Product.AddRange(products);
                    context.SaveChanges();
                }
            }
        }

}
