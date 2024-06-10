using school_manager.Models;

namespace school_manager.DTOs.SubjectDTO
{
    public class GetSubject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
