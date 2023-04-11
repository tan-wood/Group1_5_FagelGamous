using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class ColorTextileRepository : GeneralRepository<ColorTextile>
    {
        public ColorTextileRepository(MummyContext context) : base(context)
        {
        }
    }
}
