using Booking_Management.Interface;
using Booking_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IPBookingService booking;

        public BookingController(IPBookingService booking)
        {
            this.booking = booking;
        }

        [HttpGet]

        public async Task<IEnumerable<Package_Booking>>Get()
        {
            return await booking.Get();
        }

        [HttpGet("Booking_Id")]

        public async Task<List<Package_Booking>> GetById(string Booking_Id)
        {
            return await booking.GetById(Booking_Id);
        }

        [HttpPost]
        public async Task<Package_Booking> Post(Package_Booking PBooking)
        {
            return await booking.Post(PBooking);
        }

        [HttpPut]
        public async Task<Package_Booking> Put(string Booking_Id, Package_Booking PBooking)
        {
            return await booking.Put(Booking_Id, PBooking);
        }

        [HttpDelete]

        public async Task<Package_Booking> Delete(string Booking_Id)
        {
            return await booking.Delete(Booking_Id);
        }
    }
}
