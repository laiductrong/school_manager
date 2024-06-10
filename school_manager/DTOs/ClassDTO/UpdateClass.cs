using school_manager.Models;

namespace school_manager.DTOs.ClassDTO
{
    public class UpdateClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int YearId { get; set; }
        public int TeacherId { get; set; }
    }
}
