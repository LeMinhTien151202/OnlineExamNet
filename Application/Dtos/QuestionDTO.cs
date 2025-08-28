namespace ExamOnline.Dtos
{
    public class QuestionDTO
    {
        public int ExamId { get; set; }
        public string? Content { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        public string? AnswerCorrect { get; set; }
    }
}
