﻿using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class DecorationRepository : GeneralRepository<Decoration>
    {
        public DecorationRepository(MummyContext context) : base(context)
        {
        }
    }
}
