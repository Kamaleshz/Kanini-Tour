using System.ComponentModel.DataAnnotations;

namespace Tour_Package.Models
{
    public class Travel_agent
    {
        [Key]
        public int Travelagent_Id { get; set; }

        public string? Travelagent_Name { get; set; }

        public string? Travelagency_Name { get; set; }

        public string? Travelagent_Description { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number should be 10 digits")]
        public long? Travelagent_Contact { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Travelagent_Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string? Travelagent_Password { get; set; }

        public string? Travelagent_Status { get; set; }

        public ICollection<Package>? packages { get; set; }
    }
}
