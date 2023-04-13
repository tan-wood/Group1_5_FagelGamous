using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
