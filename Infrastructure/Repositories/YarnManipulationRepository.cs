using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class YarnManipulationRepository : GeneralRepository<Yarnmanipulation>
    {
        public YarnManipulationRepository(MummyContext context) : base(context)
        {
        }
    }
}
