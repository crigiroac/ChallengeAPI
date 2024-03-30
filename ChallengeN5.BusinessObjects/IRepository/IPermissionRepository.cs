using ChallengeAPI.BusinessObjects.Entities;

namespace ChallengeAPI.BusinessObjects.IRepository
{
    public interface IPermissionRepository: IGenericRepository<Permission>    
    {
        IEnumerable<Permission> GetPermissionsDetail();
        IEnumerable<Permission> GetByEmailPermissionsDetail(string Email);
    }
}
