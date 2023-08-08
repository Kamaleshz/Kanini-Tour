using Booking_Management.Interface;
using Booking_Management.Models;

namespace Booking_Management.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPayment _repo;
        private readonly IWebHostEnvironment _environment;

        public PaymentService(IPayment repo, IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }

        public async Task<IEnumerable<Payment>> Get()
        {
            return await _repo.GetPayments();
        }

        public async Task<List<Payment>> GetById(int Payment_Id)
        {
            return await _repo.GetPaymentsById(Payment_Id);
        }

        public async Task<Payment>Post(Payment payment)
        {
            return await _repo.CreatePayment(payment);
        }

        public async Task<Payment>Delete(int Payment_Id)
        {
            return await _repo.DeletePayment(Payment_Id);
        }
    }
}
