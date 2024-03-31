using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.BusinessObjects.IServices;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ChallengeAPI.UseCases.Cases.PermissionCases
{
    internal class CreatePermissionInteractor(IPermissionRepository permissionRepository,
        IOutputPort<CreatePermissionResponse> outputPort,
        IUnitOfWork unitOfWork,
        IEmployeeRepository employeeRepository,
        IPermissionTypeRepository permissionTypeRepository,
        IElasticsearchService elasticsearchService,
        IKafkaService kafkaService,
        IConfiguration configuration
           ) : IInputPort<CreatePermissionRequest>
    {
        public async Task Handle(CreatePermissionRequest request)
        {
            Permission newPermission = new();

            var Employee = employeeRepository.Get(e => e.Email == request.Email);
            var PermissionType = permissionTypeRepository.Get(e => e.PermissionTypeName == request.PermissionTypeName);

            if (Employee == null || PermissionType == null) { throw new Exception("Error Data"); }

            var exist = permissionRepository.Get(e => e.EmployeeId == Employee.Id && e.PermissionTypeId == PermissionType.Id);

            if (exist != null){throw new Exception("Permision exists");}

            newPermission.EmployeeId = Employee.Id;
            newPermission.PermissionTypeId = PermissionType.Id;
            newPermission.Enable = request.Enable;

            permissionRepository.Add(newPermission);

            await elasticsearchService.IndexDataFromSqlAsync(new PermissionElastic() { 
                Id = newPermission.Id,
                Email = newPermission.Employee.Email,
                PermissionTypeName = newPermission.PermissionType.PermissionTypeName,
                Enable =newPermission.Enable
            });

            await unitOfWork.SaveChanges();

            await kafkaService.ProducerKafkaAsync(new EventProducerKafka(){
                    OperationName= "request",
                    OperationMessague = request}, 
                configuration["Kafka:CreateTopic"]);
            

            await outputPort.Handle(new()
            {
                Id = newPermission.Id,
            });
        }
    }
}
