using Microsoft.EntityFrameworkCore;
using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Infrastructure.Repositories;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        
            private readonly MummyContext Context;

            public UnitOfWork(MummyContext context)
            {
                Context = context;
                BurialMain = new BurialMainRepository(Context);
                Color = new ColorRepository(Context);
                Decoration = new DecorationRepository(Context);
                Dimension = new DimensionRepository(Context);
                PhotoData = new PhotoDataRepository(Context);
                PhotoForm = new PhotoFormRepository(Context);
                Structure = new StructureRepository(Context);
                TeamMember = new TeamMemberRepository(Context);
                Textile = new TextileRepository(Context);
                TextileFunction = new TextileFunctionRepository(Context);
                YarnManipulation = new YarnManipulationRepository(Context);
                Analysis = new AnalysisRepository(Context);
                Burialmain = new BurialMainRepository(Context);
                Users = new UserRepository(Context);
                Roles = new RolesRepository(Context);
            }

            public IRepository<Burialmain> BurialMain { get; private set; }

            public IRepository<Color> Color { get; private set; }

            public IRepository<Decoration> Decoration { get; private set; }

            public IRepository<Dimension> Dimension { get; private set; }

            public IRepository<Photodatum> PhotoData { get; private set; }

            public IRepository<Photoform> PhotoForm { get; private set; }

            public IRepository<Structure> Structure { get; private set; }

            public IRepository<Teammember> TeamMember { get; private set; }

            public IRepository<Textile> Textile { get; private set; }

            public IRepository<Textilefunction> TextileFunction { get; private set; }

            public IRepository<Yarnmanipulation> YarnManipulation { get; private set; }

            public IRepository<Analysis> Analysis { get; private set; }

            public IRepository<Burialmain> Burialmain { get; private set; }

            public IRepository<User> Users { get; private set; }

            public IRepository<Role> Roles { get; private set; }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
