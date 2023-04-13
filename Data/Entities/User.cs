using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;

        public User(string firstName, string email, string password, int roleId) 
        {
            FirstName = firstName;
            Email = email;
            Password = password;
            RoleId = roleId;
        }
        
    }
}
