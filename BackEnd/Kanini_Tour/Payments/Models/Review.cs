using System.ComponentModel.DataAnnotations;

namespace Booking_Management.Models
{
    public class Review
    {
        [Key]

        public int Review_Id { get; set; }

        public int Package_Id { get; set; }

        public string? Comment { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }
    }
}
