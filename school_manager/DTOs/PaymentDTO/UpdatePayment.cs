namespace school_manager.DTOs.PaymentDTO
{
    public class UpdatePayment
    {
        public int StudentId { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
