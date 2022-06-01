using Microsoft.EntityFrameworkCore;

namespace recipes_and_meal_plan_api.Models
{
    public class NumberOfPeopleContext : DbContext
    {
        public NumberOfPeopleContext(DbContextOptions<NumberOfPeopleContext> options)
            : base(options)
        {
        }

        public DbSet<NumberOfPeople> NumberOfPeople { get; set; } = null!;
    }
}
