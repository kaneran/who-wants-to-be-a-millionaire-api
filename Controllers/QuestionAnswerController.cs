using Microsoft.AspNetCore.Mvc;
using who_wants_to_be_a_millionaire_api.DTOs;
using who_wants_to_be_a_millionaire_api.Entities;
using who_wants_to_be_a_millionaire_api.Services;

namespace who_wants_to_be_a_millionaire_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionAnswerController : ControllerBase
    {

        private readonly WwtbamDbContext _context;
        private readonly IQuestionAnswerService _questionAnswerService;

        private readonly ILogger<QuestionAnswerController> _logger;

        public QuestionAnswerController(WwtbamDbContext context, ILogger<QuestionAnswerController> logger, IQuestionAnswerService questionAnswerService)
        {
            _logger = logger;
            _context = context;
            _questionAnswerService = questionAnswerService;
        }

        [HttpPost(Name = "Seed")]
        public IActionResult InsertSeedData(string category)
        {
            var questions = _context.Questions.ToList();
            if(category is null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Please provide the category");
            }
            
            _questionAnswerService.ConsumeFile(category);

            return Ok();
        }

        [HttpGet(Name = "GetQuestionAnswers")]
        public QuestionAnswerResponse GetGameData(int categoryId)
        {
            return _questionAnswerService.GetGameData(categoryId);
        }
    }
}