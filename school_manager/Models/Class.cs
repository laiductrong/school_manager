namespace school_manager.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int YearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        //public int ManagerId { get; set; }
        //public Manager Manager { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public List<ClassSchedule> ClassSchedules { get; set; }
    }
}
