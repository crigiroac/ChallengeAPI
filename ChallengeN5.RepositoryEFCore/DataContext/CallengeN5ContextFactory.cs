using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChallengeAPI.RepositoryEFCore.DataContext
{
    internal class CallengeN5ContextFactory : IDesignTimeDbContextFactory<ChallengeAPIContext>
    {
        public ChallengeAPIContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ChallengeAPIContext>();
            optionBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ChallengeAPI;Trusted_Connection=true;TrustServerCertificate=true;");

            return new ChallengeAPIContext(optionBuilder.Options);
        }
    }
}
