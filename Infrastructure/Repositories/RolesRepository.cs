using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class RolesRepository : GeneralRepository<Role>
    {
        public RolesRepository(MummyContext context) : base(context)
        {
        }
    }
}
