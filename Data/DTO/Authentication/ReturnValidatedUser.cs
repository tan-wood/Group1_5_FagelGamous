namespace Group1_5_FagelGamous.Data.DTO.Authentication
{
    public class ReturnValidatedUser
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }

        public ReturnValidatedUser(string email, string firstName, string role)        {
            Email = email;
            FirstName = firstName;
            Role = role;
        }

    }
}
