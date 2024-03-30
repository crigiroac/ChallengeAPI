using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.RepositoryEFCore.DataContext;

namespace ChallengeAPI.RepositoryEFCore.Repositories
{
    internal class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ChallengeAPIContext context) : base(context)
        {
        }
    }
}
