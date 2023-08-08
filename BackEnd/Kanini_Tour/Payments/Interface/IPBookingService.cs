using Booking_Management.Models;

namespace Booking_Management.Interface
{
    public interface IPBookingService
    {
        public Task<IEnumerable<Package_Booking>> Get();

        public Task<List<Package_Booking>> GetById(string Booking_Id);

        public Task<Package_Booking> Post(Package_Booking PBooking);

        public Task<Package_Booking> Put(string Booking_Id, Package_Booking PBooking);

        public Task<Package_Booking> Delete(string Booking_Id);
    }
}
