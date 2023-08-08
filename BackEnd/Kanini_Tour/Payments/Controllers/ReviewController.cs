using Booking_Management.Interface;
using Booking_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService review;

        public ReviewController(IReviewService review)
        {
            this.review = review;
        }

        [HttpGet]

        public async Task<List<Review>> Get()
        {
            return await review.Get();
        }

        [HttpGet("Review_Id")]

        public async Task<IEnumerable<Review>> GetById(int id)
        {
            return await review.GetById(id);
        }

        [HttpPost]

        public async Task<Review> Post(Review Review)
        {
            return await review.Post(Review);
        }

        [HttpPut]

        public async Task<Review> Put(int Review_Id,Review Review)
        {
            return await review.Put(Review_Id, Review);
        }

        [HttpDelete]

        public async Task<Review> Delete(int Review_Id)
        {
            return await review.Delete(Review_Id);
        }
    }
}
