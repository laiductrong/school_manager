namespace school_manager.DTOs.UserAccountDTO
{
    public class AddAccount
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public int RoleId { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public int? ManagerId { get; set; }
    }
}
