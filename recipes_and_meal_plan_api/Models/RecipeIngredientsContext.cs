using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipes_and_meal_plan_api.Models {
    public class RecipeIngredientsContext : DbContext {
        public RecipeIngredientsContext(DbContextOptions<RecipeIngredientsContext> options)
            : base(options) {
        }

        public DbSet<RecipeIngredients> RecipeIngredients { get; set; } = null!;
    }
}
