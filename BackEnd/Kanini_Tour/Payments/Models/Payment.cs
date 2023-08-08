using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Management.Models
{
    public class Payment
    {
        [Key]

        public int Payment_Id { get; set; }

        [ForeignKey("package_booking")]
        public string Booking_Id { get; set; }

        [Required]
        public long Card_Number { get; set; }

        [Required]
        public int CVV { get; set; }

        [Required]
        public string? Expiry_Date { get; set; }

        [Required]
        public string? Card_Holder_Name { get; set; }

        public Package_Booking? package_booking { get; set; }
    }
}
