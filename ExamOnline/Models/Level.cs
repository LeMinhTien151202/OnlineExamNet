
namespace ExamOnline.Models
{
    [Table("levels")]
    public class Level
    {
        [Key]
        [Column("level_id")]
        public int LevelId { get; set; }

        [Column("level_name")]
        [StringLength(20)]
        public string? LevelName { get; set; }

        // Navigation property
        //public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}
