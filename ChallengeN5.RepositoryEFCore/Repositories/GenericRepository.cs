using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.RepositoryEFCore.DataContext;
using System.Linq.Expressions;

namespace ChallengeAPI.RepositoryEFCore.Repositories
{
    internal class GenericRepository<T>(ChallengeAPIContext context) : IGenericRepository<T> where T : EntityBase
    {
        public void Add(T entity)
        {
            context.Add(entity);
        }

        public void Delete(Guid id)
        {
            context.Remove(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }
}
