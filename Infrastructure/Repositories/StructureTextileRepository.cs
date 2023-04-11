using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class StructureTextileRepository : GeneralRepository<StructureTextile>
    {
        public StructureTextileRepository(MummyContext context) : base(context)
        {
        }
    }
}
