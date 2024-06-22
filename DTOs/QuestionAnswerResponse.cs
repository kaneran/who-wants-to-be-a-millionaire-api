namespace who_wants_to_be_a_millionaire_api.DTOs
{
    public record QuestionAnswerResponse
    {
        public List<QuestionAnswer> results { get; set; }
        public int response_code { get; set; }
    }
}
