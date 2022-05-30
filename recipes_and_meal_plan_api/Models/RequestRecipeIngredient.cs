using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipes_and_meal_plan_api.Models
{
    public class RequestRecipeIngredient
    {
        public int Id { get; set; }
        public int Request_recipe_id { get; set; }
        public int Ingredient_id { get; set; }
        public int Amount { get; set; }
        public int Unit_id { get; set; }
    }
}
