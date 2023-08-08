using System.ComponentModel.DataAnnotations;

namespace Travellers.Models
{
    public class Traveller
    {
        [Key]

        public int Traveller_Id { get; set; }

        public string? Traveller_Name { get; set;}

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Traveller_Email { get; set;}

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string? Traveller_Password { get; set;}

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number should be 10 digits")]
        public long? Traveller_Contact { get; set;}
    }
}
