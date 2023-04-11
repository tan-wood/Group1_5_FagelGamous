using Group1_5_FagelGamous.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{

    public abstract class GeneralRepository<T> : IRepository<T> where T : class
    {
        protected readonly MummyContext Context;
        protected DbSet<T> DbSet { get; set; }
        protected GeneralRepository(MummyContext context) 
        {
            Context = context;
            //This is already giving us the single table for our use
            DbSet = context.Set<T>();
        }
        public T Add(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public IEnumerable<T>? Find(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public T? GetById(int id)
        {
            return DbSet.Find(id);
        }

        public T? GetById(long id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToArray();
        }
    }
}
