using PetReviewApp.Models;

namespace PetReviewApp.Interfaces
{
    public interface IPetRepository
    {
        ICollection<Pet> GetPets();
        Pet GetPet(int id);
        Pet GetPet(string name);
        int GetPetRating(int id);
        bool PetExists(int id);
    }
}
 
