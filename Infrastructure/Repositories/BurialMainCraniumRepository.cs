﻿using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class BurialMainCraniumRepository : GeneralRepository<BurialmainCranium>
    {
        public BurialMainCraniumRepository(MummyContext context) : base(context)
        {
        }
    }
}
