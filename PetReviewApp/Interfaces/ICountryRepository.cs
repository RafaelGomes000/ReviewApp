using PetReviewApp.Models;

namespace PetReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int id);
        ICollection<Owner> GetOwnersFromACountry(int id);
        bool CountryExists (int id);
    }
}
