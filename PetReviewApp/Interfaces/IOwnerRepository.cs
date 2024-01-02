using PetReviewApp.Models;

namespace PetReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int id); 
        ICollection<Owner> GetOwnerOfAPet(int id);
        ICollection<Pet> GetPetByOwner(int id);
        bool OwnerExists(int id);
    }
}
