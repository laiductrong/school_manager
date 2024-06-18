
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_manager.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("subject_id")]
        public int? SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        //public Manager Manager { get; set; }
        //public List<Class> Classes { get; set; }
        //public List<Grade> Grades { get; set; }
        //public Salary Salary { get; set; }
        //public List<ClassSchedule> ClassSchedules { get; set; }
    }
}
