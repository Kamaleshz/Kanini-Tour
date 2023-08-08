using Booking_Management.Models;

namespace Booking_Management.Interface
{
    public interface IPayment
    {
        public Task<IEnumerable<Payment>> GetPayments();

        public Task<List<Payment>> GetPaymentsById(int Payment_Id);

        public Task<Payment> CreatePayment(Payment payment);

        public Task<Payment> DeletePayment(int Payment_Id);
    }
}
