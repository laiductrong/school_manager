using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_manager.Models
{
    public class Class
    {
        [Key]
        [Column("class_id")]
        public int ClassId { get; set; }
        [Column("class_name")]
        public string ClassName { get; set; }
        [Column("year_id")]
        public int YearId { get; set; }
        //[ForeignKey("FK__Class__year_id__412EB0B6")]

        public virtual AcademicYear AcademicYear { get; set; }
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        //public virtual Teacher Teacher { get; set; }
        //public List<Student> Students { get; set; }
        //public List<ClassSchedule> ClassSchedules { get; set; }
    }
}
