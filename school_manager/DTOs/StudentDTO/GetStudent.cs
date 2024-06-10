using school_manager.Models;

namespace school_manager.DTOs.StudentDTO
{
    public class GetStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
