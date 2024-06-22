using who_wants_to_be_a_millionaire_api.Entities;

namespace who_wants_to_be_a_millionaire_api.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
    }
}