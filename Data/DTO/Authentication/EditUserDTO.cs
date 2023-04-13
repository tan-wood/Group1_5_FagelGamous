namespace Group1_5_FagelGamous.Data.DTO.Authentication
{
    public class EditUserDTO
    {
        public string AdminEmail { get; set; } = null!;
        public int UserId { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserFirstName { get; set; } = null!;
        public int UserRoleId { get; set; }
    }
}
