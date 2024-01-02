using PetReviewApp.Data;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _dataContext;

        public CountryRepository(DataContext data)
        {
            _dataContext = data;
        }
        public bool CountryExists(int id)
        {
            return _dataContext.Countries.Any(x => x.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _dataContext.Countries.OrderBy(x => x.Id).ToList();
        }

        public Country GetCountry(int id)
        {
            return _dataContext.Countries.FirstOrDefault(x => x.Id == id);
        }

        public Country GetCountryByOwner(int id)
        {
            return _dataContext.Owners.Where(x => x.Id == id).Select(x => x.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int id)
        {
            return _dataContext.Owners.Where(x => x.Country.Id == id).ToList();
        }
    }
}
