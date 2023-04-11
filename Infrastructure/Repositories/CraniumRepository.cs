using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class CraniumRepository : GeneralRepository<Cranium>
    {
        public CraniumRepository(MummyContext context) : base(context)
        {
        }
    }
}
