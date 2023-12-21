using System.Linq.Expressions;

namespace TestTask.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    }
}
