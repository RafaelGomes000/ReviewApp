using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Dto;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("GetCategories")]
        [ProducesResponseType(200, Type = typeof(ICollection<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("GetCategory")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int id)
        {
            if (!_categoryRepository.CategoryExist(id)) return NotFound();

            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(id));

            if(!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("GetPetByCategory")]
        [ProducesResponseType(200, Type = typeof(ICollection<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetPetByCategory(int id)
        {
            if (!_categoryRepository.CategoryExist(id)) return NotFound();

            var category = _mapper.Map<List<PetDto>>(
                _categoryRepository.GetPetByCategory(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(category);
        }

    }
}
