using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class BodyAnalysisChartRepository : GeneralRepository<Bodyanalysischart>
    {
        public BodyAnalysisChartRepository(MummyContext context) : base(context)
        {
        }
    }
}
