namespace school_manager.Models
{
    public class ClassSchedule
    {
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int YearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public int TimeSlot { get; set; }
        public DateTime ClassDate { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
