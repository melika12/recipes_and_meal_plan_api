using Microsoft.EntityFrameworkCore;

namespace recipes_and_meal_plan_api.Models
{
    public class RequestContext : DbContext
    {
        public RequestContext(DbContextOptions<RequestContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; } = null!;
    }
}
