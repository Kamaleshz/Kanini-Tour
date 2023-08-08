using Booking_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking_Management.Context
{
    public class BookingContext : DbContext
    {
        public DbSet<Package_Booking> package_bookings { get; set; }

        public DbSet<Payment> payments { get; set; }

        public DbSet<Review> reviews { get; set; }

        public BookingContext(DbContextOptions<BookingContext> options) : base(options) { }
    }
}
