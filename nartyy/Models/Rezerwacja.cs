using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace nartyy.Models
{
    public class Rezerwacja
    {
        [Key]
        public int IDSprzet { get; set; }

        public string? TypSprzetu { get; set; }

        public DateTime? DataOdbioru { get; set; }

        public DateTime? DataZwrotu { get; set; }

        public virtual  ICollection<Narty> Sprzet_Narty{ get; set; }

        public virtual ICollection<ButyNarciarskie> Sprzet_Buty { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}

