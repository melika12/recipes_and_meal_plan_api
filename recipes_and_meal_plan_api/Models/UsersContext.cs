using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipes_and_meal_plan_api.Models {
    public class UsersContext : DbContext {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options) {
        }

        public DbSet<Users> Users { get; set; } = null!;
    }
}
