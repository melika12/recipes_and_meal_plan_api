using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipes_and_meal_plan_api.Models {
    public class IngredientsContext : DbContext {
        public IngredientsContext(DbContextOptions<IngredientsContext> options)
            : base(options) {
        }

        public DbSet<Ingredients> Ingredients { get; set; } = null!;
    }
}
