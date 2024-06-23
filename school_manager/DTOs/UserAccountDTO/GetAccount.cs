using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace school_manager.DTOs.UserAccountDTO
{
    public class GetAccount
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public int? ManagerId { get; set; }
    }
}
