using Booking_Management.Context;
using Booking_Management.Interface;
using Booking_Management.Models;
using Booking_Management.Repository;

namespace Booking_Management.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReview _repo;
        private readonly IWebHostEnvironment _environment;

    public ReviewService(IReview repo, IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }

        public async Task<Review> Post(Review Review)
        {
            return await _repo.CreateReview(Review);
        }

        public async Task<List<Review>> Get()
        {
            return await _repo.GetReviews();
        }

        public Task<IEnumerable<Review>> GetById(int Review_Id)
        {
            return _repo.GetReviewsById(Review_Id);
        }

        public async Task<Review>Put(int Review_Id,Review Review)
        {
            return await _repo.UpdateReview(Review_Id, Review);
        }

        public async Task<Review> Delete(int Review_Id)
        {
            return await _repo.DeleteReview(Review_Id);
        }
    }
}
