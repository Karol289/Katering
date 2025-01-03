﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Food
{

    public class Meal
    {
        [Key]
        public int MealId { get; set; }


        [ForeignKey("DietId")]
        public Diet? DietType { get; set; }

        [ForeignKey("MealCategoryId")]
        public MealCategory? MealCategory { get; set; }

        public string? Name { get; set; }
        public int? Calories { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
    }

}

