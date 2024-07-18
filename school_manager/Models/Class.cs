using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_manager.Models
{
    [Table("Class")]
    public class Class
    {
        [Key]
        [Column("class_id")]
        public int ClassId { get; set; }
        [Column("class_name")]
        public string ClassName { get; set; }
        [Column("year_id")]
        public int AcademicYearYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        //public List<Student> Students { get; set; }
        //public List<ClassSchedule> ClassSchedules { get; set; }
    }
}
