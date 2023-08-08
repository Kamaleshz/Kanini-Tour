using Booking_Management.Models;

namespace Booking_Management.Interface
{
    public interface IPaymentService
    {
        public Task<IEnumerable<Payment>> Get();

        public Task<List<Payment>> GetById(int Payment_Id);

        public Task<Payment> Post(Payment payment);

        public Task<Payment> Delete(int Payment_Id);
    }
}
