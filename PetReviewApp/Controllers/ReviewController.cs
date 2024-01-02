using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Dto;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IPetRepository _petRepository;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper, IPetRepository petRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _petRepository = petRepository;
        }

        [HttpGet("GetReviews")]
        [ProducesResponseType(200, Type = typeof(ICollection<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("GetReview")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int id)
        {
            if (!_reviewRepository.ReviewExists(id)) return NotFound();

            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(review);
        }

        [HttpGet("GetReviewsOfAPet")]
        [ProducesResponseType(200, Type = typeof(ICollection<Review>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsOfAPet (int id)
        {
            if(!_petRepository.PetExists(id)) return NotFound();

            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsOfAPet(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(reviews);
        }
    }
}
