using school_manager.Models;

namespace school_manager.DTOs.ClassDTO
{
    public class GetClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int YearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        public int TeacherId { get; set; }
        //public virtual Teacher Teacher { get; set; }
        //public List<Student> Students { get; set; }
        //public List<ClassSchedule> ClassSchedules { get; set; }
    }
}
