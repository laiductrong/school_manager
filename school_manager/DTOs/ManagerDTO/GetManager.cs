using school_manager.Models;

namespace school_manager.DTOs.ManagerDTO
{
    public class GetManager
    {
        public int ManagerId { get; set; }
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
