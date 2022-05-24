using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipes_and_meal_plan_api.Models {
    public class RecipeIngredients {
        public int Id { get; set; }
        public int recipe_id { get; set; }
        public int ingredient_id { get; set; }
        public int Amount { get; set; }
        public int unit_id { get; set; }
    }
}
