using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class BiologicalRepository : GeneralRepository<Biological>
    {
        public BiologicalRepository(MummyContext context) : base(context)
        {
        }
    }
}
