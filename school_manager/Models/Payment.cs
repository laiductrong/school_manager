using System.ComponentModel.DataAnnotations.Schema;

namespace school_manager.Models
{
    [Table("Payment")]
    public class Payment
    {
        [Column("payment_id")]
        public int PaymentId { get; set; }
        [Column("student_id")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("year_id")]
        public int AcademicYearYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        
    }
}
