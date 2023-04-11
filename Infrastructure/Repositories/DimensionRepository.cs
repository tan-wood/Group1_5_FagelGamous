using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class DimensionRepository : GeneralRepository<Dimension>
    {
        public DimensionRepository(MummyContext context) : base(context)
        {
        }
    }
}
