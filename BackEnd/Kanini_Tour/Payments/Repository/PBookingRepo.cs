using Booking_Management.Context;
using Booking_Management.Interface;
using Booking_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Booking_Management.Models.Package_Booking;

namespace Booking_Management.Service
{
    public class PBookingRepo : IPBooking
    {
        private readonly BookingContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PBookingRepo(BookingContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<Package_Booking>> GetPBooking()
        {
            return await _context.package_bookings.ToListAsync();
        }

        public async Task<List<Package_Booking>> GetPBookingById(string Booking_Id)
        {
            try
            {
                return await _context.package_bookings.Where(x => x.Booking_Id == Booking_Id).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Package_Booking> CreatePBooking(Package_Booking PBooking)
        {
            PBooking.Booking_Status = ConfirmationStatus.Requested;

            {
                var random = new Random();
                long min = 10000000;
                long max = 99999999;
                long randomNumber = (long)(random.NextDouble() * (max - min + 1)) + min;
                PBooking.Booking_Id = randomNumber.ToString();
            }
            _context.package_bookings.Add(PBooking);
            await _context.SaveChangesAsync();

            return PBooking;
        }

        public async Task<Package_Booking> UpdatePBooking(string Booking_Id, Package_Booking PBooking)
        {
            try
            {
                var existingBooking = await _context.package_bookings.FindAsync(Booking_Id);
                if (existingBooking == null)
                {
                    return null;
                }

                existingBooking.Traveller_Id = PBooking.Traveller_Id;
                existingBooking.Package_Id = PBooking.Package_Id;
                existingBooking.Booking_Date = PBooking.Booking_Date;
                existingBooking.Travellers_Count = PBooking.Travellers_Count;
                existingBooking.Booking_Status = PBooking.Booking_Status;
                await _context.SaveChangesAsync();

                return existingBooking;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task <Package_Booking> DeletePBooking(string Booking_Id)
        {
            try
            {
                Package_Booking PBooking = await _context.package_bookings.FirstOrDefaultAsync(x => x.Booking_Id == Booking_Id);
                if (PBooking != null)
                {
                    _context.package_bookings.Remove(PBooking);
                    _context.SaveChangesAsync();
                    return PBooking;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
