using Booking_Management.Context;
using Booking_Management.Interface;
using Booking_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking_Management.Repository
{
    public class ReviewRepo : IReview
    {
        private readonly BookingContext _context;
        private readonly IWebHostEnvironment _environment;
        public ReviewRepo(BookingContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment; 
        }

        public async Task<List<Review>> GetReviews()
        {
            return await _context.reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsById(int Review_Id)
        {
            try
            {
                return await _context.reviews.Where(x => x.Review_Id == Review_Id).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<Review> CreateReview(Review review)
        {
            _context.reviews.Add(review);
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<Review> UpdateReview(int Review_Id, Review review)
        {
            try
            {
                var existingReview = await _context.reviews.FindAsync(Review_Id);
                if (existingReview == null)
                {
                    return null;
                }

                existingReview.Review_Id = review.Review_Id;
                existingReview.Package_Id = review.Package_Id;
                existingReview.Comment = review.Comment;
                existingReview.Rating = review.Rating;
                await _context.SaveChangesAsync();

                return existingReview;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Review> DeleteReview(int Review_Id)
        {
            try
            {
                Review Review = await _context.reviews.FirstOrDefaultAsync(x => x.Review_Id == Review_Id);
                if (Review != null)
                {
                    _context.reviews.Remove(Review);
                    _context.SaveChangesAsync();
                    return Review;
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