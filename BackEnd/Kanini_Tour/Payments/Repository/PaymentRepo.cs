using Booking_Management.Context;
using Booking_Management.Interface;
using Booking_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using static Booking_Management.Models.Package_Booking;

namespace Booking_Management.Repository
{
    public class PaymentRepo : IPayment
    {
        private readonly BookingContext _bookingContext;
        private readonly IWebHostEnvironment _environment;

        public PaymentRepo(BookingContext bookingContext, IWebHostEnvironment environment)
        {
            _bookingContext = bookingContext;
            _environment = environment;
        }   

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _bookingContext.payments.ToListAsync();
        }

        public async Task<List<Payment>> GetPaymentsById(int Payment_Id)
        {
            try
            {
                return await _bookingContext.payments.Where(x => x.Payment_Id == Payment_Id).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task <Payment> CreatePayment(Payment payment)
        {
            _bookingContext.payments.AddAsync(payment);
            await _bookingContext.SaveChangesAsync();

            Package_Booking associatedBooking = _bookingContext.package_bookings.Find(payment.Booking_Id);
            if (associatedBooking != null)
            {
                associatedBooking.Booking_Status = ConfirmationStatus.Confirmed;
                _bookingContext.SaveChangesAsync();
            }
            return payment;
        }
        
        public async Task<Payment> DeletePayment(int Payment_Id)
        {
            try
            {
                Payment Payment = await _bookingContext.payments.FirstOrDefaultAsync(x => x.Payment_Id == Payment_Id);
                if (Payment != null)
                {
                    _bookingContext.payments.Remove(Payment);
                    _bookingContext.SaveChangesAsync();
                    return Payment;
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
