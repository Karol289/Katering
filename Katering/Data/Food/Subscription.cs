
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Food
{

    public class Subscription
    {
        [Key]
        public int SubscriptionID { get; set; }

        [ForeignKey("DietId")]
        public Diet? Diet {get; set;}

        public string? Name { get; set; }
        public double? Price { get; set; }

    }

}

