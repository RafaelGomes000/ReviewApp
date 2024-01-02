using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Dto;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpGet("GetReviewers")]
        [ProducesResponseType(200, Type = typeof(ICollection<Reviewer>))]
        public IActionResult GetReviewers()
        {
            var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(reviewers);
        }

        [HttpGet("GetReviewer")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int id)
        {
            if (!_reviewerRepository.ReviewerExists(id)) return NotFound();

            var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("GetReviewsByReviewer")]
        [ProducesResponseType(200, Type = typeof(ICollection<Reviewer>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByReviewer(int id)
        {
            if (!_reviewerRepository.ReviewerExists(id)) return NotFound();

            var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewsByReviewer(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(reviews);
        }
    }
}
