using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_manager.Models
{
    public class Subject
    {
        [Key]
        [Column("subject_id")]
        public int SubjectId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
