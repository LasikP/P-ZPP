using System.ComponentModel.DataAnnotations;


namespace nartyy.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Imię jest wymagane")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon jest wymagany")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Wiadomość jest wymagana")]
        public string Message { get; set; }
    }


}
