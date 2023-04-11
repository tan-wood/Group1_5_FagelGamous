using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class PhotoDataRepository : GeneralRepository<Photodatum>
    {
        public PhotoDataRepository(MummyContext context) : base(context)
        {
        }
    }
}
