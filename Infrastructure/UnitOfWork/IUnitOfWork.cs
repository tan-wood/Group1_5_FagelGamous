using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Infrastructure.Repositories;

namespace PureTruthApi.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        
        int Complete();
    }
}
