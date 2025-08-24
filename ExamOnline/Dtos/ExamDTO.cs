namespace ExamOnline.Dtos
{
    public class ExamDTO
    {
        [Required, Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive integer.")]
        public int CategoryId { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "LevelId must be a positive integer.")]
        public int LevelId { get; set; }
        [Required, MinLength(1), MaxLength(100)]
        public string ExamName { get; set; }
        [Required, MinLength(1), MaxLength(100)]
        public string Pictures { get; set; }
    }
}
