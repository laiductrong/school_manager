using school_manager.Models;

namespace school_manager.DTOs.ClassScheeduleDTO
{
    public class AddCS
    {
        public int ClassId { get; set; }
        public int YearId { get; set; }
        public int TimeSlot { get; set; }
        public int TeacherId { get; set; }
    }
}
