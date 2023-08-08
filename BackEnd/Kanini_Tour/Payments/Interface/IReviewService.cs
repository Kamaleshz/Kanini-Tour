using Booking_Management.Models;

namespace Booking_Management.Interface
{
    public interface IReviewService
    {
        public Task<List<Review>> Get();

        public Task<IEnumerable<Review>> GetById(int Review_Id);

        public Task<Review> Post(Review review);

        public Task<Review> Put(int Review_Id, Review review);

        public Task<Review> Delete(int Review_Id);
    }
}
