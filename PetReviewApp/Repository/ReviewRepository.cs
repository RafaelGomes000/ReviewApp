using PetReviewApp.Data;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _dataContext;

        public ReviewRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Review GetReview(int id)
        {
            return _dataContext.Reviews.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Review> GetReviews()
        {
            return _dataContext.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPet(int id)
        {
            return _dataContext.Reviews.Where(x => x.Pet.Id == id).ToList();
        }

        public bool ReviewExists(int id)
        {
            return _dataContext.Reviews.Any(x => x.Id == id);
        }
    }
}
