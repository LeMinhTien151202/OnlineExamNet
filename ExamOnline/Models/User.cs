
namespace ExamOnline.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("role_id")]
        public int? RoleId { get; set; }

        [Column("user_name")]
        [StringLength(100)]
        public string? UserName { get; set; }

        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Column("phone")]
        [StringLength(20)]
        public string? Phone { get; set; }

        [Column("pass_word")]
        [StringLength(100)]
        public string? PassWord { get; set; }

        // Navigation properties
        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }

        public virtual ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
