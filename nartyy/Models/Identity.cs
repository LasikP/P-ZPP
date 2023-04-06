using System.ComponentModel.DataAnnotations;

namespace nartyy.Models
{
    public class Identity
    {
        [Key]
        public int IDIdentity { get; set; }
        public string? Usename { get; set; }
        public string? Password { get; set; }
        
    }
}
