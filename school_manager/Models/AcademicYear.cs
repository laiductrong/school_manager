using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace school_manager.Models
{
    [Table("AcademicYear")]
    public class AcademicYear
    {
        [Key]
        [Column("year_id")]
        public int YearId { get; set; }

        [Column("year_name")]
        public string YearName { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
