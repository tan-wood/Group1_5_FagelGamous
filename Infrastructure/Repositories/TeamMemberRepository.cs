﻿using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class TeamMemberRepository : GeneralRepository<Teammember>
    {
        public TeamMemberRepository(MummyContext context) : base(context)
        {
        }
    }
}
