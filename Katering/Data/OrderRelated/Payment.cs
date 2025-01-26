
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Orders
{

    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public double Value { get; set; }

        public PaymentStatus? Status { get; set; }

        public DateTime? Date { get; set; }

        public PaymentMethod Method { get; set; }



        public enum PaymentStatus
        {
            //Zmienic wedlug zapotrzebowania w aplikacji
            PENDING, CONFIRMED, IN_PROGRESS, CANCELLED, FAILED, COMPLETED
        }

        public enum PaymentMethod
        {
            BLIK, DEBIT_CARD //.....
        }
        // klucz obcy do kontrahenta?
    }

}

