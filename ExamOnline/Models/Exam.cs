
using System.Reflection.Emit;

namespace ExamOnline.Models
{
    [Table("exams")]
    public class Exam : IAuditable
    {
        [Key]
        [Column("exam_id")]
        public int ExamId { get; set; }

        [Column("category_id")]
        public int? CategoryId { get; set; }

        [Column("level_id")]
        public int? LevelId { get; set; }

        [Column("exam_name")]
        [StringLength(100)]
        public string? ExamName { get; set; }

        [Column("pictures")]
        [StringLength(100)]
        public string? Pictures { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_up")]
        public DateTime UpdatedUp { get; set; }

        // Navigation properties
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [ForeignKey("LevelId")]
        public virtual Level? Level { get; set; }

        //public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        //public virtual ICollection<Result> Results { get; set; } = new List<Result>();
     
    }
}
