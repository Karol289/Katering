

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Katering.Data.Food;



namespace Katering.Data.Orders
{

    public class SubscriptionOrder
    {
        [Key]
        public int SubscriptionOrderId { get; set; }


        [ForeignKey("MealId")]
        public Meal? Payment { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }

}

