using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.User
{
    public class Contractor
    {
        [Key]
        public int Id { get; set; }

        public required string CompanyName { get; set; }

        public int NIP { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]

        public User User { get; set; }
    }
}
