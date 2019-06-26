using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVU.Models
{
    public class RecipeProduct
    {
        public long Id { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
