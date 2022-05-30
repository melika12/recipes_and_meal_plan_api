using Microsoft.EntityFrameworkCore;

namespace recipes_and_meal_plan_api.Models
{
    public class RequestRecipeIngredientContext : DbContext
    {
        public RequestRecipeIngredientContext(DbContextOptions<RequestRecipeIngredientContext> options)
            : base(options)
        {
        }

        public DbSet<RequestRecipeIngredient> RequestRecipeIngredients { get; set; } = null!;
    }
}
