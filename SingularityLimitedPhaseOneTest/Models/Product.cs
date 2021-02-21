using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingularityLimitedPhaseOneTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Boolean DeleteStatus { get; set; }
        public Boolean LockStatus { get; set; }

    }
}
