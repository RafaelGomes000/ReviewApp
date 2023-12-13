using PetReviewApp.Models;

namespace PetReviewApp.Interfaces
{
    public interface IPetRepository
    {
        public ICollection<Pet> GetPets();
    }
}
