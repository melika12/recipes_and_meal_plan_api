using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipes_and_meal_plan_api.Models {
    public class AdminUsersContext : DbContext {
        public AdminUsersContext(DbContextOptions<AdminUsersContext> options)
            : base(options) {
        }

        public DbSet<AdminUsers> AdminUsers { get; set; } = null!;
    }
}
