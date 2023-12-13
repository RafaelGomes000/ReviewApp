using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPetRepository _petRepository;
        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Pet>))]
        public IActionResult GetPets()
        {
            var pets = _petRepository.GetPets();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pets);
        }
    }
}
