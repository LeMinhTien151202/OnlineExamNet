namespace ExamOnline.Dtos
{
    public class ResultDTO
    {
        public int ResultId { get; set; }
        public int? UserId { get; set; }
        public int? ExamId { get; set; }
        public string? Score { get; set; }
    }
}
