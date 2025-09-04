
namespace ExamOnline.Models
{
    [Table("results")]
    public class Result
    {
        [Key]
        [Column("result_id")]
        public int ResultId { get; set; }

        [Column("user_id")]
        public string? UserId { get; set; }

        [Column("exam_id")]
        public int? ExamId { get; set; }

        [Column("score")]
        [StringLength(20)]
        public string? Score { get; set; }

        // Navigation properties
        //[ForeignKey("UserId")]
        //public virtual User? User { get; set; }

        [ForeignKey("ExamId")]
        public virtual Exam? Exam { get; set; }
    }
}
