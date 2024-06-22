using who_wants_to_be_a_millionaire_api.DTOs;
using who_wants_to_be_a_millionaire_api.Entities;

namespace who_wants_to_be_a_millionaire_api.Services
{
    public interface IQuestionAnswerService
    {
        List<Question> ConsumeFile(string category);

        void InsertCategory(string category);

        Category GetCategory(string category);
        QuestionAnswerResponse GetGameData(int categoryId);
    }
}
