namespace school_manager.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
