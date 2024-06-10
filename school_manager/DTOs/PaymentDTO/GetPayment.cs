using school_manager.Models;

namespace school_manager.DTOs.PaymentDTO
{
    public class GetPayment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
