namespace school_manager.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public decimal BaseRate { get; set; }
        public int TeachingHours { get; set; }
        public decimal Bonus { get; set; }
    }
}
