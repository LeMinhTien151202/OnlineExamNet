namespace ExamOnline.Dtos
{
    public class LevelDTO
    {
        [Required, MinLength(1), MaxLength(100)]
        public string? LevelName { get; set; }
    }
}
