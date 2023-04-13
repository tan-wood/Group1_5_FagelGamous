namespace Group1_5_FagelGamous.Data.DTO.Authentication
{
    public class EditUserModel
    {
        public string Email { get; set; } = null!;
        public string CurrentPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}
