namespace school_manager.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
