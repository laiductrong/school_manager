namespace school_manager.DTOs.GradeDTO
{
    public class UpdateGrade
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public decimal Score { get; set; }
        public int YearId { get; set; }
    }
}
