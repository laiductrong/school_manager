using System.Security.Claims;

namespace school_manager.Models
{
    public class AcademicYear
    {
        public int YearId { get; set; }
        public String YearName {  get; set; }
        public List<Class> Classes { get; set; }
    }
}
