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
    }
}
