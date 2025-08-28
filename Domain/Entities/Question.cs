
namespace ExamOnline.Models
{
    [Table("questions")]
    public class Question
    {
        [Key]
        [Column("question_id")]
        public int QuestionId { get; set; }

        [Column("exam_id")]
        public int? ExamId { get; set; }

        [Column("content")]
        [StringLength(500)]
        public string? Content { get; set; }

        [Column("answer_A")]
        [StringLength(50)]
        public string? AnswerA { get; set; }

        [Column("answer_B")]
        [StringLength(50)]
        public string? AnswerB { get; set; }

        [Column("answer_C")]
        [StringLength(50)]
        public string? AnswerC { get; set; }

        [Column("answer_D")]
        [StringLength(50)]
        public string? AnswerD { get; set; }

        [Column("answer_correct")]
        [StringLength(50)]
        public string? AnswerCorrect { get; set; }

        // Navigation property
        [ForeignKey("ExamId")]
        public virtual Exam? Exam { get; set; }
    }
}
