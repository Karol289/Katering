using System.ComponentModel.DataAnnotations;

namespace Katering.Data
{
    public class Moderator
    {
        [Key]
        public int Id { get; set; }

        public int ModeratorNumber { get; set; }
    }
}
