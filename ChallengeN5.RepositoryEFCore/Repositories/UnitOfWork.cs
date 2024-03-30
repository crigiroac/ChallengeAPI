using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.RepositoryEFCore.DataContext;

namespace ChallengeAPI.RepositoryEFCore.Repositories
{
    internal class UnitOfWork(ChallengeAPIContext context) : IUnitOfWork
    {
        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }
    }
}
