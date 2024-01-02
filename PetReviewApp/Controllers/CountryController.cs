using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Dto;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet("GetCountries")]
        [ProducesResponseType(200, Type = typeof(ICollection<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("GetCountry")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int id)
        {
            if (!_countryRepository.CountryExists(id)) return NotFound();

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("GetCountryByOwner")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryByOwner(int id)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(id));

            if(!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("GetOwnersFromACountry")]
        [ProducesResponseType(200, Type = typeof(ICollection<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnersFromACountry(int id)
        {
            if (!_countryRepository.CountryExists(id)) return NotFound();

            var owners = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersFromACountry(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(owners);
        }
    }
}
