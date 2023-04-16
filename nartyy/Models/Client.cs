﻿using System.ComponentModel.DataAnnotations;

namespace nartyy.Models
{
    public class Client
    {
        [Key]
        public int IDClient { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Adress { get; set; }

        public string Roles { get; set; }
      
    }
}
