

namespace ExamOnline.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("category_name")]
        [StringLength(30)]
        public string? CategoryName { get; set; }

        // Navigation property
        //public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}
