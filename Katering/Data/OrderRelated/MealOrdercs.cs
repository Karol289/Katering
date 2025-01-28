
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Katering.Data.Food;



namespace Katering.Data.Orders
{

    public class MealOrder
    {
        [Key]
        public int MealOrderId { get; set; }
        
        public int? MealId { get; set; }
        public int? OrderId { get; set; }

        [ForeignKey("MealId")]
        public Meal? Payment { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }

}

