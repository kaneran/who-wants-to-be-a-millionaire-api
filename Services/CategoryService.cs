using who_wants_to_be_a_millionaire_api.Entities;

namespace who_wants_to_be_a_millionaire_api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly WwtbamDbContext _context;
        public CategoryService(WwtbamDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
