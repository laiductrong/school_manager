using school_manager.Models;

namespace school_manager.DTOs.PaymentDTO
{
    public class GetPayment
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int YearId { get; set; }
        public string YearName { get; set; }
    }
}
