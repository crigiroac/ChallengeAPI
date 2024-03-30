using ChallengeAPI.BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChallengeAPI.RepositoryEFCore.DataContext
{
    public class ChallengeAPIContext(DbContextOptions<ChallengeAPIContext>options): DbContext(options)
    {
        public virtual DbSet<Employee> Employees {get; set;}
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Log> Logs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
