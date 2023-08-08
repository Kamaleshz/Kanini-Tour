using Booking_Management.Interface;
using Booking_Management.Models;

namespace Booking_Management.Service
{
    public class PBookingService : IPBookingService
    {
        private readonly IPBooking _repo;
        private readonly IWebHostEnvironment _environment;

        public PBookingService(IPBooking repo, IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }

        public async Task<Package_Booking> Post(Package_Booking PBooking)
        {
            return await _repo.CreatePBooking(PBooking);
        }

        public  async Task<IEnumerable<Package_Booking>> Get()
        {
            return await  _repo.GetPBooking();
        }

        public async Task<List<Package_Booking>> GetById(string Booking_Id)
        {
            return await  _repo.GetPBookingById(Booking_Id);
        }

        public async Task<Package_Booking> Put(string Booking_Id, Package_Booking PBooking)
        {
            return await _repo.UpdatePBooking(Booking_Id, PBooking);
        }

        public async Task<Package_Booking> Delete(string Booking_Id)
        {
            return await _repo.DeletePBooking(Booking_Id);
        }
    }
}
