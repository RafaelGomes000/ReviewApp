using PetReviewApp.Data;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly DataContext _dataContext;

        public PetRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Pet> GetPets()
        {
            return _dataContext.Pets.OrderBy(p => p.Id).ToList();
        }

        public Pet GetPet(int id)
        {
            return _dataContext.Pets.FirstOrDefault(x => x.Id == id);
        }

        public Pet GetPet(string name)
        {
            return _dataContext.Pets.FirstOrDefault(x => x.Name == name);
        }

        public int GetPetRating(int id)
        {
            var review = _dataContext.Reviews.Where(x => x.Pet.Id == id);

            if(review.Count() <= 0) return 0;

            return review.Sum(x => x.Rating) / review.Count();
        }

        public bool PetExists(int id)
        {
            return _dataContext.Pets.Any(x => x.Id == id);
        }
    }
}
