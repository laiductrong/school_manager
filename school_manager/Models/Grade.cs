using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace school_manager.Models
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        [Column("grade_id")]
        public int GradeId { get; set; }
        [Column("student_id")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [Column("score")]
        public decimal Score { get; set; }
        [Column("year_id")]
        public int YearId { get; set; }
        public virtual AcademicYear Year { get; set; }
    }
}
