using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Infrastructure.Repositories;

namespace Group1_5_FagelGamous.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
            IRepository<Analysis> Analysis { get; }
            IRepository<Burialmain> BurialMain { get; }
            IRepository<Color> Color { get; }
            IRepository<Decoration> Decoration { get; }
            IRepository<Dimension> Dimension { get; }
            IRepository<Photodatum> PhotoData { get; }
            IRepository<Photoform> PhotoForm { get; }
            IRepository<Structure> Structure { get; }
            IRepository<Teammember> TeamMember { get; }
            IRepository<Textile> Textile { get; }
            IRepository<Textilefunction> TextileFunction { get; }
            IRepository<Yarnmanipulation> YarnManipulation { get; }
            IRepository<User> Users { get; }
            IRepository<Role> Roles { get; }
            int Complete();
        

    }
}
