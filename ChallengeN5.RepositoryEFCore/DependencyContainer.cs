using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.RepositoryEFCore.DataContext;
using ChallengeAPI.RepositoryEFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeAPI.RepositoryEFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChallengeAPIContext>(o => {
                o.UseSqlServer(configuration.GetConnectionString("ChallengeConnection"));
            });

            
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
