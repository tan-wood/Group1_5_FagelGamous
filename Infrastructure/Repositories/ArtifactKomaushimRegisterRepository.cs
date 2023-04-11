using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{
    public class ArtifactKomaushimRegisterRepository : GeneralRepository<Artifactkomaushimregister>
    {
        public ArtifactKomaushimRegisterRepository(MummyContext context) : base(context)
        {
        }
    }
}
