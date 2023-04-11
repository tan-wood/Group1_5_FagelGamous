using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class BurialMainBodyAnalysisChartRepository : GeneralRepository<BurialmainBodyanalysischart>
    {
        public BurialMainBodyAnalysisChartRepository(MummyContext context) : base(context)
        {
        }
    }
}
