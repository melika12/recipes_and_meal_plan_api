using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipes_and_meal_plan_api.Models {
    public class UnitsContext : DbContext {
        public UnitsContext(DbContextOptions<UnitsContext> options)
            : base(options) {
        }

        public DbSet<Units> Units { get; set; } = null!;
    }
}
