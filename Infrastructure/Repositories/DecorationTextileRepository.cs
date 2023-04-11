using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class DecorationTextileRepository : GeneralRepository<DecorationTextile>
    {
        public DecorationTextileRepository(MummyContext context) : base(context)
        {
        }
    }
}
