using Microsoft.AspNetCore.Mvc;
using who_wants_to_be_a_millionaire_api.DTOs;
using who_wants_to_be_a_millionaire_api.Entities;
using who_wants_to_be_a_millionaire_api.Services;

namespace who_wants_to_be_a_millionaire_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly WwtbamDbContext _context;
        private readonly ICategoryService _categoryService;

        private readonly ILogger<CategoryController> _logger;

        public CategoryController(WwtbamDbContext context, ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _context = context;
            _categoryService = categoryService;
        }

        [HttpGet(Name = "GetCategories")]
        public List<Category> GetCategories()
        {
            return _categoryService.GetCategories();
        }
    }
}