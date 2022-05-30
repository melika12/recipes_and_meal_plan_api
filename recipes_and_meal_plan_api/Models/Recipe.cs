using System.Drawing;

namespace recipes_and_meal_plan_api.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public byte[] Img { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Course_of_action { get; set; }
    }
}
