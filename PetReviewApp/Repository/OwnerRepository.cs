using PetReviewApp.Data;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _dataContext;

        public OwnerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Owner> GetOwners()
        {
            return _dataContext.Owners.OrderBy(x => x.Id).ToList();
        }
        public Owner GetOwner(int id)
        {
            return _dataContext.Owners.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Owner> GetOwnerOfAPet(int id)
        {
            return _dataContext.PetOwners.Where(x => x.Pet.Id == id).Select(x => x.Owner).ToList();
        }

        public ICollection<Pet> GetPetByOwner(int id)
        {
            return _dataContext.PetOwners.Where(x => x.Owner.Id == id).Select(x => x.Pet).ToList();
        }

        public bool OwnerExists(int id)
        {
            return _dataContext.Owners.Any(x => x.Id == id);
        }
    }
}
