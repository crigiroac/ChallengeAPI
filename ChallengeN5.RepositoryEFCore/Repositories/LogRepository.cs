using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.RepositoryEFCore.DataContext;

namespace ChallengeAPI.RepositoryEFCore.Repositories
{
    internal class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(ChallengeAPIContext context) : base(context)
        {
        }
    }
}
