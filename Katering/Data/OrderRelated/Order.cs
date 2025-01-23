
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Katering.Data.Users;

namespace Katering.Data.Orders
{

    public class Order
    {
        [Key]
        public int OrderID { get; set; }


        [ForeignKey("PaymentId")]
        public Payment? Payment { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

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

