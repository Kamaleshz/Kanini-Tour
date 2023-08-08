using Booking_Management.Interface;
using Booking_Management.Models;
using Booking_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService payments;

        public PaymentController(IPaymentService payments)
        {
            this.payments = payments;
        }

        [HttpGet]

        public async Task<IEnumerable<Payment>> Get()
        {
            return await payments.Get();
        }

        [HttpGet("Payment_Id")]

        public async Task<List<Payment>>GetById(int Payment_Id)
        {
            return await payments.GetById(Payment_Id);
        }

        [HttpPost]

        public async Task<Payment>Post(Payment payment)
        {
            return await payments.Post(payment);
        }

        [HttpDelete]

        public async Task<Payment>Delete(int Payment_Id)
        {
            return await payments.Delete(Payment_Id);
        }
    }
}
