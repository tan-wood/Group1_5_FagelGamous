using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class PhotoDataTextileRepository : GeneralRepository<PhotodataTextile>
    {
        public PhotoDataTextileRepository(MummyContext context) : base(context)
        {
        }
    }
}
