
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Food
{

    public class MealCategory
    {
        [Key]
        public int MealCategoryId { get; set; }

        public string? Name { get; set; }

        // klucz obcy do kontrahenta?
    }

}

