using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.UseCases.Cases;
using ChallengeAPI.UseCases.Cases.PermissionCases;
using ChallengeAPI.UseCases.Common;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeAPI.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddTransient<IInputPort<CreateEmployeeRequest>, CreateEmployeeInteractor>();
            services.AddTransient<IInputPort<CreatePermissionTypeRequest>, CreatePermisionTypeInteractor>();
            services.AddTransient<IInputPort<CreatePermissionRequest>,CreatePermissionInteractor>();
            services.AddTransient<IInputPort<IGetAllPermissionRequest>, GetAllPermissionInteractor>();
            services.AddTransient<IInputPort<GetByEmailPermissionRequest>, GetByEmailPermissionInteractor>();
            services.AddTransient<IInputPort<UpdatePermisionRequest>, UpdatePermissionInteractor>();

            return services;
        }
    }
}
