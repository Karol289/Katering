
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Order
{

    public class Order
    {
        [Key]
        public int OrderID { get; set; }


        [ForeignKey("PaymentID")]
        public int? PaymentID { get; set; }

        //[ForeignKey("UserID")]
        //public int? UserID { get; set; }

        public OrderStatus? Status { get; set; }

        public DateTime? Date { get; set; }

        public double? Discount { get; set; }



        public enum OrderStatus
        {
            //Zmienic wedlug zapotrzebowania w aplikacji
            PENDING, CONFIRMED, IN_PROGRESS, CANCELLED, FAILED, COMPLETED 
        }
        // klucz obcy do kontrahenta?
    }

}

