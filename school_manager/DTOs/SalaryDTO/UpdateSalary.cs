using school_manager.Models;

namespace school_manager.DTOs.SalaryDTO
{
    public class UpdateSalary
    {
        public int SalaryId { get; set; }
        public int TeacherId { get; set; }
        public decimal BaseRate { get; set; }
        public int TeachingHours { get; set; }
        public decimal Bonus { get; set; }
    }
}
