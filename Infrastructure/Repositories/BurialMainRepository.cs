﻿using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class BurialMainRepository : GeneralRepository<Burialmain>
    {
        public BurialMainRepository(MummyContext context) : base(context)
        {
        }
    }
}
