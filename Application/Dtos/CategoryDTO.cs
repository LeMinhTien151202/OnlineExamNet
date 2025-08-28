namespace ExamOnline.Dtos
{
    public class CategoryDTO
    {
        [Required, MinLength(3), MaxLength(50)]
        public string? CategoryName { get; set; }
    }
}
