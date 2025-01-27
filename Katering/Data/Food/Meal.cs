

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Food
{

    public class Meal
    {
        [Key]
        public int MealId { get; set; }


        //[ForeignKey("DietId")]
        //public Diet? Diet { get; set; }

        //[ForeignKey("MealCategoryId")]
        //public MealCategory? MealCategory { get; set; }

        [ForeignKey("DietId")]
        public int? DietTypeId { get; set; }
        public Diet? Diet { get; set; }

        [ForeignKey("MealCategoryId")]
        public int? MealCategoryId { get; set; }
        public MealCategory? MealCategory { get; set; }


        public string? Name { get; set; }
        public int? Calories { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }

        public Meal() { }   
    }

}

