

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Food
{

    class Meal
    {
        [Key]
        public int MealID { get; set; }

        [ForeignKey("Diet")]
        public int? DietType { get; set; }
        [ForeignKey("MealCategory")]
        public int? MealCategory { get; set; }

        public string? Name { get; set; }
        public int? Calories { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
    }

}

