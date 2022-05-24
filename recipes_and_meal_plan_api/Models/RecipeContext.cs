using Microsoft.EntityFrameworkCore;

namespace recipes_and_meal_plan_api.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; } = null!;
    }
}
