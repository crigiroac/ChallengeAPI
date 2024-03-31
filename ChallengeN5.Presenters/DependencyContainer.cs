using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Presenters.Employee;
using ChallengeAPI.Presenters.Permission;
using ChallengeAPI.Presenters.PermissionType;
using ChallengeAPI.UseCases.Common;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeAPI.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<IOutputPort<CreateEmployeeResponse>, CreateEmployeePresenter>();
            services.AddScoped<IOutputPort<CreatePermissionTypeResponse>, CreatePermissionTypePresenter>();
            services.AddScoped<IOutputPort<CreatePermissionResponse>, CreatePermissionPresenter>();
            services.AddScoped<IOutputPort<IEnumerable<GetPermissionResponse>>, GetAllPermissionPresenter>();
            services.AddScoped<IOutputPort<IEnumerable<GetPermissionResponse>>, GetByEmailPermissionPresenter>();
            services.AddScoped<IOutputPort<IEnumerable<PermissionElasticResponse>>, GetByEmailPermissionElasticPresenter>();

            return services;
        }
    }
}
