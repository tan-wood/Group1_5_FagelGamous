using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class ColorRepository : GeneralRepository<Color>
    {
        public ColorRepository(MummyContext context) : base(context)
        {
        }
    }

}
