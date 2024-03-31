using ChallengeAPI.BusinessObjects.Entities;
using System.Linq.Expressions;

namespace ChallengeAPI.BusinessObjects.IServices
{
    public interface IElasticsearchService
    {
        Task IndexDataFromSqlAsync(PermissionElastic permissionElastic);
        Task UpdateDataAsync(PermissionElastic permissionElastic);
        Task<IEnumerable<PermissionElastic>> GetByEmailDataAsync(string email);
    }
}
