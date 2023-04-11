using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class StructureRepository : GeneralRepository<Structure>
    {
        public StructureRepository(MummyContext context) : base(context)
        {
        }
    }
}
