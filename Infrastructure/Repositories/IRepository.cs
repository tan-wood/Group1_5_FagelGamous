using System.Linq.Expressions;

namespace Group1_5_FagelGamous.Infrastructure.Repositories
{

    public interface IRepository<T> where T : class
    {
        T? GetById(int id);
        /// <summary>
        /// Used for versatile querying
        /// </summary>
        /// <returns></returns>

        IEnumerable<T> GetAll();
        IQueryable<T> Query();
        /// <summary>
        /// Get all where
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T>? Find(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns newly created entity's id</returns>
        void Add(T entity);
        /// <summary>
        /// Adds a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Returns a list of all the ids that were created</returns>
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
