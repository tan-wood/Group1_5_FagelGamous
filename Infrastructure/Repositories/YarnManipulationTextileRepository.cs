using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class YarnManipulationTextileRepository : GeneralRepository<YarnmanipulationTextile>
    {
        public YarnManipulationTextileRepository(MummyContext context) : base(context)
        {
        }
    }
}
