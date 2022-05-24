using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipes_and_meal_plan_api.Models {
    public class WeekDaysContext : DbContext {
        public WeekDaysContext(DbContextOptions<WeekDaysContext> options)
            : base(options) {
        }

        public DbSet<WeekDays> WeekDays { get; set; } = null!;
    }
}
