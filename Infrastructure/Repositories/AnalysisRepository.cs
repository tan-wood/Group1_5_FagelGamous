using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class AnalysisRepository : GeneralRepository<Analysis>
    {
        public AnalysisRepository(MummyContext context) : base(context)
        {
        }
    }
}
