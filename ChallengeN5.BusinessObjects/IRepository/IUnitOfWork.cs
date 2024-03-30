namespace ChallengeAPI.BusinessObjects.IRepository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}
