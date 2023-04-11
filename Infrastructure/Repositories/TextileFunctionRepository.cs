using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class TextileFunctionRepository : GeneralRepository<Textilefunction>
    {
        public TextileFunctionRepository(MummyContext context) : base(context)
        {
        }
    }
}
