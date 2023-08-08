using Booking_Management.Models;

namespace Booking_Management.Interface
{
    public interface IPBooking
    {
        public Task<IEnumerable<Package_Booking>> GetPBooking();

        public Task<List<Package_Booking>> GetPBookingById(string Booking_Id);

        public Task<Package_Booking> CreatePBooking(Package_Booking PBooking);

        public Task<Package_Booking> UpdatePBooking(string Booking_Id, Package_Booking PBooking);

        public Task <Package_Booking> DeletePBooking(string Booking_Id);

    }
}
