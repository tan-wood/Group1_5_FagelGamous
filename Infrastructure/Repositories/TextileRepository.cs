using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class TextileRepository : GeneralRepository<Textile>
    {
        public TextileRepository(MummyContext context) : base(context)
        {
        }
    }
}
