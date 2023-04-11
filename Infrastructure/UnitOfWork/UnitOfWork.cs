using Microsoft.EntityFrameworkCore;
using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Infrastructure.Repositories;
using Group1_5_FagelGamous.Data;

namespace PureTruthApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MummyContext Context;
        public UnitOfWork(MummyContext context)
        {
            Context = context;
        }

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
