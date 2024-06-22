using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_manager.Models
{
    
    public class Manager
    {
        [Key]
        [Column("manager_id")]
        public int ManagerId { get; set; }
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
