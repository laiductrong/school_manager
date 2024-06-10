namespace school_manager.DTOs.SalaryDTO
{
    public class AddSalary
    {
        public int TeacherId { get; set; }
        public decimal BaseRate { get; set; }
        public int TeachingHours { get; set; }
        public decimal Bonus { get; set; }
    }
}
