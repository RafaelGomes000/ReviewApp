using PetReviewApp.Data;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _dataContext;

        public ReviewerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Reviewer GetReviewer(int id)
        {
            return _dataContext.Reviewers.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _dataContext.Reviewers.OrderBy(x => x.Id).ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int id)
        {
            return _dataContext.Reviews.Where(x => x.Reviewer.Id == id).ToList();
        }

        public bool ReviewerExists(int id)
        {
            return _dataContext.Reviewers.Any(x => x.Id == id);
        }

    }
}
