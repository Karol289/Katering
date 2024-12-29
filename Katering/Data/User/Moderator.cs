using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Users
{
    public class Moderator
    {
        [Key]
        public int Id { get; set; }

        public int ModeratorNumber { get; set; }

        [ForeignKey("UserId")]

        public User User { get; set; }
    }
}
