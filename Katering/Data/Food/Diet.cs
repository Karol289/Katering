
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katering.Data.Food
{

    public class Diet
    {
        [Key]
        public int DietID { get; set; }

        public string? Name { get; set; }

        // klucz obcy do kontrahenta?
    }

}

