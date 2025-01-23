
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Food
{

    public class Diet
    {
        [Key]
        public int DietId { get; set; }

        public string? Name { get; set; }

    }

}

