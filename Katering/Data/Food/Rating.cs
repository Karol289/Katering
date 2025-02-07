﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Katering.Data.Users;

namespace Katering.Data.Food
{

    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        public int? MealId { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("MealId")]
        public Meal? Meal{ get; set; }

       
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int? Value { get; set; }
        public DateTime? Date { get; set; }

        public string? Content { get; set; }

   
    }

}

