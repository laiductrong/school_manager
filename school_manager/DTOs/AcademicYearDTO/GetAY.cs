using school_manager.Models;

namespace school_manager.DTOs.AcademicYearDTO
{
    public class GetAY
    {
        public int YearId { get; }
        public String YearName { get; }
        public List<Class> Classes { get; }
    }
}
