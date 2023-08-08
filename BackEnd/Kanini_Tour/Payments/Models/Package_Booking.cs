using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Management.Models
{
    public enum ConfirmationStatus
    {
        [Display(Name = "Requested")]
        Requested,

        [Display(Name = "Confirmed")]
        Confirmed
    }
    public class Package_Booking
    {
        [Key]
        public string? Booking_Id { get; set; }

        public int? Traveller_Id { get; set; }

        public int? Package_Id { get; set; }

        public DateTime? Booking_Date { get; set;}

        public int? Travellers_Count { get; set; }

        public DateTime? Booked_On { get; set; }

        public ConfirmationStatus? Booking_Status { get; set; }

        public Package_Booking()
        {
            Booking_Status = ConfirmationStatus.Requested;
            Booking_Date = DateTime.Now;
        }
    }
}
