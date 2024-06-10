using school_manager.Models;

namespace school_manager.DTOs.GradeDTO
{
    public class GetGrade
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public decimal Score { get; set; }
    }
}
