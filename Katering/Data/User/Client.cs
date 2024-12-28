﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Katering.Data.User
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey("UserId")]

        public User User { get; set; }

    }
}
