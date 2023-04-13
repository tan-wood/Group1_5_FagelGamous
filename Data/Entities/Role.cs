using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class Role
    {
        public Role(string roleName)
        {
            Users = new HashSet<User>();
            RoleName = roleName;
        } 

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; } = null!;

    }
}
