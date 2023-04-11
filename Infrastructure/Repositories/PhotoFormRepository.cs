using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class PhotoFormRepository : GeneralRepository<Photoform>
    {
        public PhotoFormRepository(MummyContext context) : base(context)
        {
        }
    }
}
