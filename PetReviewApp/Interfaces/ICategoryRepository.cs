using PetReviewApp.Models;

namespace PetReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pet> GetPetByCategory(int id);
        bool CategoryExist(int id);
    }
}
