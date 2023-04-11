﻿using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class DimensionTextileRepository : GeneralRepository<DimensionTextile>
    {
        public DimensionTextileRepository(MummyContext context) : base(context)
        {
        }
    }
}
