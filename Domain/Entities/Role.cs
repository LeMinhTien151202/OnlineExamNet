
namespace ExamOnline.Models
{
    [Table("roles")]
    public class Role
    {
        [Key]
        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("role_name")]
        [StringLength(20)]
        public string? RoleName { get; set; }

        // Navigation property
        //public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
