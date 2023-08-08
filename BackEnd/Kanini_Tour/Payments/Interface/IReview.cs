using Booking_Management.Models;

namespace Booking_Management.Interface
{
    public interface IReview
    {
        public Task<List<Review>> GetReviews();

        public Task<IEnumerable<Review>> GetReviewsById(int Review_Id);

        public Task<Review> CreateReview(Review review);

        public Task<Review> UpdateReview(int Review_Id, Review review);

        public Task<Review> DeleteReview(int Review_Id);
    }
}
