using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVU.Models
{
    public class Recipe
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string CuisineName { get; set; }

        public User RecipeAuthor { get; set; }
        public IEnumerable<RecipeStep> Steps { get; set; }
        public IEnumerable<RecipeProduct> RequiredProducts { get; set; }
    }
}
