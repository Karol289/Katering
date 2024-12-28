

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Food
{

    public class Rating
    {
        [Key]
        public int RatingID { get; set; }

        [ForeignKey("Meal")]
        public int? MealID { get; set; }

        // TODO : Klucz obcy wskazujacy na uzytkwonika ktorego jest ocena
        //[ForeignKey("User")]
        //public int? UserID { get; set; }

        public int? Value { get; set; }
        public DateTime? Date { get; set; }

        public string? Content { get; set; }

   
    }

}

