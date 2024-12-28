using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Users
{
    public class Administrator
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
