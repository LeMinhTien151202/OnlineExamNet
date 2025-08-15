namespace ExamOnline.Dtos
{
    public class ExamDTO
    {
        public int ExamId { get; set; }
        public int? CategoryId { get; set; }
        public int? LevelId { get; set; }
        public string? ExamName { get; set; }
        public string? Pictures { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedUp { get; set; }
    }
}
