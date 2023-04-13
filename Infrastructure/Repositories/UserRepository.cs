using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class UserRepository : GeneralRepository<User>
    {
        public UserRepository(MummyContext context) : base(context)
        {
        }
    }
}
