
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Food
{

    class Sunscription
    {
        [Key]
        public int SubscriptionID { get; set; }

        [ForeignKey("DietID")]
        public int? DietID {get; set;}

        public string? Name { get; set; }
        public double? Price { get; set; }

    }

}

