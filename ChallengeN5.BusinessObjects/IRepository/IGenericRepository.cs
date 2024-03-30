using ChallengeAPI.BusinessObjects.Entities;
using System.Linq.Expressions;

namespace ChallengeAPI.BusinessObjects.IRepository
{
    public interface IGenericRepository <T> where T : EntityBase
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T Get(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
    }
}
