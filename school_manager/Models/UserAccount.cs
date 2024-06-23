using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace school_manager.Models
{
    public class UserAccount
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        [Column("student_id")]
        public int? StudentId { get; set; }

        [Column("teacher_id")]
        public int? TeacherId { get; set; }

        [Column("manager_id")]
        public int? ManagerId { get; set; }

        //public ICollection<UserRole> UserRoles { get; set; }

    }
}
