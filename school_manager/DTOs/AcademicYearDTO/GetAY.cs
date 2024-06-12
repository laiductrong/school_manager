using school_manager.Models;

namespace school_manager.DTOs.AcademicYearDTO
{
    public class GetAY
    {
        public int YearId { get; set; }
        public String YearName { get; set; }
        //public List<Class> Classes { get; }
    }
}
