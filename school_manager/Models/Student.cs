using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace school_manager.Models
{
    public class Student
    {
        [Key]
        [Column("student_id")]
        public int StudentId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("class_id")]
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
        //public List<Grade> Grades { get; set; }
        //public List<Payment> Payments { get; set; }
    }
}
