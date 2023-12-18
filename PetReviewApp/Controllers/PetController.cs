using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Data;
using PetReviewApp.Dto;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;
using System.Reflection.Metadata;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public PetController(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        [HttpGet("GetPets")]
        [ProducesResponseType(200, Type = typeof(ICollection<Pet>))]
        public IActionResult GetPets()
        {
            var pets = _mapper.Map<List<PetDto>>(_petRepository.GetPets());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pets);
        }

        [HttpGet("GetPet")]
        [ProducesResponseType(200, Type = typeof(Pet))]
        [ProducesResponseType(400)]
        public IActionResult GetPet(int id)
        {
            if (!_petRepository.PetExists(id)) return NotFound();

            var pet = _mapper.Map<PetDto>(_petRepository.GetPet(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pet);
        }

        [HttpGet("GetPetRating")]
        [ProducesResponseType(200, Type = typeof(Pet))]
        [ProducesResponseType(400)]
        public IActionResult GetPetRating(int id)
        {
            if(!_petRepository.PetExists(id)) return NotFound();

            var rating = _petRepository.GetPetRating(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(rating.ToString("f1"));
        }

        /*
        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(Pet))]
        [ProducesResponseType(400)] 
        public IActionResult GetPet(string name)
        {
            if (!_petRepository.PetExists((int)name))
        }
        */
    }
}
