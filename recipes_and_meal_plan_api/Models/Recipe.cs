using System.Drawing;

namespace recipes_and_meal_plan_api.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Img { get; set; }
        public string Img_extension { get; set; }
        public string Description { get; set; }
        public string Course_of_action { get; set; }
        public string Count_of_people { get; set; }
    }
}
