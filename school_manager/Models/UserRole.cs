using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace school_manager.Models
{
    public class UserRole
    {
        [Key]
        [Column("user_role_id")]
        public int UserRoleId { get; set; }

        [ForeignKey("UserAccount")]
        [Column("user_id")]
        public int UserId { get; set; }
        public UserAccount UserAccount { get; set; }

        [ForeignKey("Role")]
        [Column("role_id")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
