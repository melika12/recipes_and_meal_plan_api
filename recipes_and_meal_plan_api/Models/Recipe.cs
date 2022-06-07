using System.Drawing;

namespace recipes_and_meal_plan_api.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Time { get; set; }
        public string Course_of_action { get; set; }
        public int Count_of_people { get; set; }
        public int Request { get; set; }
    }
}
