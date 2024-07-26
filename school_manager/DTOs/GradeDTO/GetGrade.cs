using school_manager.Models;

namespace school_manager.DTOs.GradeDTO
{
    public class GetGrade
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public decimal Score { get; set; }
        public int YearId { get; set; }
        public string YearName { get; set; }
    }
}
