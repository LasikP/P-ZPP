using System.ComponentModel.DataAnnotations;

namespace nartyy.Models
{
    public class Client
    {
        [Key]
        public int IDClient { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Adres { get; set; }
        public virtual ICollection<Identity> Identities { get; set; }
    }
}
