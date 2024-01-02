using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Dto;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;
using PetReviewApp.Repository;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [HttpGet("GetOwners")]
        [ProducesResponseType(200, Type = typeof(ICollection<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(owners);
        }

        [HttpGet("GetOwner")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int id)
        {
            if (!_ownerRepository.OwnerExists(id)) return NotFound();

            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet("GetOwnerOfAPet")]
        [ProducesResponseType(200, Type = typeof(ICollection<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerOfAPet(int id)
        {
            if (!_ownerRepository.OwnerExists(id)) return NotFound();

            var owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnerOfAPet(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet("GetPetByOwner")]
        [ProducesResponseType(200, Type = typeof(ICollection<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetPetByOwner(int id)
        {
            if (!_ownerRepository.OwnerExists(id)) return NotFound();

            var owner = _mapper.Map<List<PetDto>>(_ownerRepository.GetPetByOwner(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(owner);
        }
    }
}

