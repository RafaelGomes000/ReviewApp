using PetReviewApp.Models;

namespace PetReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewsOfAPet(int id);
        bool ReviewExists(int id);
    }
}
