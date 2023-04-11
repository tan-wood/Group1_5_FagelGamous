using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class TextileFunctionTextileRepository : GeneralRepository<TextilefunctionTextile>
    {
        public TextileFunctionTextileRepository(MummyContext context) : base(context)
        {
        }
    }
}
