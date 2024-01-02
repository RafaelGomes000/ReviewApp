using PetReviewApp.Data;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Category> GetCategories()
        {
            return _dataContext.Categories.OrderBy(x => x.Id).ToList();
        }

        public Category GetCategory(int id)
        {
            return _dataContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Pet> GetPetByCategory(int id)
        {
            return _dataContext.PetCategories.Where(x => x.CategoryId == id).Select(x => x.Pet).ToList();
        }

        public bool CategoryExist(int id)
        {
            return _dataContext.Categories.Any(x => x.Id == id);
        }
    }
}
