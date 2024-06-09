using school_manager.Models;

namespace school_manager.DTOs.ClassDTO
{
    public class AddClass
    {
        public string ClassName { get; set; }
        public int YearId { get; set; }
        public int TeacherId { get; set; }
    }
}
