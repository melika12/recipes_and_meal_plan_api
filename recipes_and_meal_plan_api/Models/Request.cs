using System.Drawing;

namespace recipes_and_meal_plan_api.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Ingredient_name { get; set; }
        public string Unit_name { get; set; }
        public string Recipe_name { get; set; }
        public byte[] Recipe_img { get; set; }
        public string Recipe_img_extension { get; set; }
        public string Recipe_description { get; set; }
        public string Recipe_course_of_action { get; set; }
        public int Recipe_count_of_people { get; set; }
    }
}
