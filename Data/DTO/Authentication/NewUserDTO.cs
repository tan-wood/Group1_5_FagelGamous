namespace Group1_5_FagelGamous.Data.DTO.Authentication
{
    public class NewUserDTO
    {
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string TempPassword { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
