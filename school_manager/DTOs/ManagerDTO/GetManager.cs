using school_manager.Models;

namespace school_manager.DTOs.ManagerDTO
{
    public class GetManager
    {
        public int ManagerId { get; set; }
        public int TeacherId { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? SubjectId { get; set; }
        public string? SubjectName { get; set; }
    }
}
