using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.RepositoryEFCore.DataContext;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAPI.RepositoryEFCore.Repositories
{
    internal class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly ChallengeAPIContext context;
        public PermissionRepository(ChallengeAPIContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Permission> GetByEmailPermissionsDetail(string Email)
        {
            return context.Permissions.Include(e => e.Employee).Include(e => e.PermissionType).Where(e => e.Employee.Email == Email);
        }

        public IEnumerable<Permission> GetPermissionsDetail()
        {
            return context.Permissions.Include(e => e.Employee).Include(e => e.PermissionType);
        }
    }
}
