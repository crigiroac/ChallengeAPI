using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.RepositoryEFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAPI.RepositoryEFCore.Repositories
{
    internal class PermissionTypeRepository : GenericRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(ChallengeAPIContext context) : base(context)
        {
        }
    }
}
