using System.Text;
using who_wants_to_be_a_millionaire_api.DTOs;
using who_wants_to_be_a_millionaire_api.Entities;

namespace who_wants_to_be_a_millionaire_api.Services
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly WwtbamDbContext _context;
        public QuestionAnswerService(WwtbamDbContext context)
        {
            _context = context;
        }

        public List<Question> ConsumeFile(string category)
        {

            List<Question> questions = new List<Question>();
            String line;
            InsertCategory(category);
            var mCategory = GetCategory(category);

            string dataFolderName = "data";
            string startupPath = Environment.CurrentDirectory;
            string dataPath = Path.Combine(startupPath, "..", dataFolderName, category);
            string fullDataPath = Path.GetFullPath(dataPath);



            using (var sr = new StreamReader(fullDataPath))
            {
                line = sr.ReadLine();
                line = sr.ReadLine();
                var question = new Question();
                question.Category_ID = mCategory.Category_ID;
                var sb = new StringBuilder();
                var isCorrectAnswerSetup = false;
                string correctAnswerText = null;
                while (line != null) {
                    if (line.StartsWith("#Q"))
                    {
                        var questionLine = line.Substring(3);
                        sb.Append(questionLine);
                    }
                    else if (line.StartsWith("^"))
                    {
                        question.Text = sb.ToString();
                        sb.Clear();

                        correctAnswerText = line.Replace("^", "").Trim();
                        var correctAnswer = new Answer() { Text = correctAnswerText, Answer_Type_CD = "C" };

                        question.Answers.Add(correctAnswer);
                        isCorrectAnswerSetup = true;
                    }
                    else if (line.Trim().Length > 0 && isCorrectAnswerSetup && (line.StartsWith("A") || line.StartsWith("B") || line.StartsWith("C") || line.StartsWith("D")))
                    {
                        //Current answer being processed is not the correct answer
                        var answerText = line.Substring(2);
                        if (correctAnswerText != answerText)
                        {
                            var answer = new Answer() { Text = answerText, Answer_Type_CD = "I" };
                            question.Answers.Add(answer);
                        }
                    }
                    else if (line.Trim().Length == 0 && question.Answers.Count == 0)
                    {
                        sb.Append('\n');
                    }
                    else if (line.Trim().Length > 0)
                    {
                        sb.Append(line);
                    }
                    else
                    {
                        questions.Add(question);
                        question = new Question();
                        question.Category_ID = mCategory.Category_ID;
                        correctAnswerText = null;
                        isCorrectAnswerSetup = false;
                    }
                    line = sr.ReadLine();
                }
            }

            var multipleChoiceQuestions = questions.Where(q => q.Answers.Count == 4).DistinctBy(q => q.Text).ToList();
            _context.Questions.AddRange(multipleChoiceQuestions);
            _context.SaveChanges();
            return multipleChoiceQuestions;
        }

        public void InsertCategory(string category)
        {
            _context.Categories.Add(new Category() { Name = category });
            _context.SaveChanges();
        }

        public Category? GetCategory(string category)
        {
            return _context.Categories.FirstOrDefault(c => c.Name == category);
        }

        public QuestionAnswerResponse GetGameData(int categoryId)
        {
            var questionAnswers = GetQuestionAnswers(categoryId);
            var response = new QuestionAnswerResponse() { response_code = 0, results = questionAnswers};
            return response;
        }

        private List<QuestionAnswer> GetQuestionAnswers(int categoryId)
        {
            Random rand = new Random();
            var questionIds = _context.Questions.Where(q => q.Category_ID == categoryId).Select(q => q.Question_ID).ToList();
            var filteredQuestions = new List<QuestionAnswer>();
            if (questionIds.Count > 0)
            {
                var count = questionIds.Count - 1;
                
                while (filteredQuestions.Count != 15)
                {
                    int randomQuestionId = questionIds[rand.Next(count)];
                    var question = _context.Questions.Where(q => q.Question_ID == randomQuestionId).FirstOrDefault();
                    var answers = _context.Answers.Where(a => a.Question_ID == randomQuestionId).ToList();
                    var isUniqueQuestion = !filteredQuestions.Any(q => q.question == question.Text);
                    if (isUniqueQuestion)
                        filteredQuestions.Add(new QuestionAnswer() { question = question.Text, incorrect_answers = question.Answers.Where(a => a.Answer_Type_CD == "I").Select(a => a.Text).ToList(), correct_answer = question.Answers.Where(a => a.Answer_Type_CD == "C").Select(a => a.Text).SingleOrDefault() });
                }
                return filteredQuestions;
            }
            else
            {
                return filteredQuestions;
            }
            
        }
    } 
}
