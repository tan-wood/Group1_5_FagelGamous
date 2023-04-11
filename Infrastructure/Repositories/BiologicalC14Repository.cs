using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class BiologicalC14Repository : GeneralRepository<BiologicalC14>
    {
        public BiologicalC14Repository(MummyContext context) : base(context)
        {
        }
    }
}
