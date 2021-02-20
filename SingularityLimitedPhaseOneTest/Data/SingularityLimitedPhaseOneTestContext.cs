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
        public SingularityLimitedPhaseOneTestContext (DbContextOptions<SingularityLimitedPhaseOneTestContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
