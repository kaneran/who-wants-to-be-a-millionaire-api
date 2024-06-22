using System;

namespace who_wants_to_be_a_millionaire_api.DTOs;

public record QuestionAnswer
{
    public string question { get; set; }
    public List<string> incorrect_answers { get; set; }
    public string correct_answer { get; set; }
}
