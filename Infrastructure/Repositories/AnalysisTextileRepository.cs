using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class AnalysisTextileRepository : GeneralRepository<AnalysisTextile>
    {
        public AnalysisTextileRepository(MummyContext context) : base(context)
        {
        }
    }
}
