using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class NewsArticleRepository : GeneralRepository<Newsarticle>
    {
        public NewsArticleRepository(MummyContext context) : base(context)
        {
        }
    }
}
