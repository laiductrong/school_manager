using school_manager.Models;

namespace school_manager.DTOs.SalaryDTO
{
    public class GetSalary
    {
        public int SalaryId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public decimal BaseRate { get; set; }
        public int TeachingHours { get; set; }
        public decimal Bonus { get; set; }
    }
}
