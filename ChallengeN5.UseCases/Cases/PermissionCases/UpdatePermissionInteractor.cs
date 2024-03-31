using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.BusinessObjects.IServices;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.Elasticsearch;
using ChallengeAPI.Kafka;
using ChallengeAPI.UseCases.Common;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ChallengeAPI.UseCases.Cases.PermissionCases
{
    internal class UpdatePermissionInteractor(IPermissionRepository permissionRepository,
        IUnitOfWork unitOfWork,
        IEmployeeRepository employeeRepository,
        IPermissionTypeRepository permissionTypeRepository,
        IElasticsearchService elasticsearchService,
        IKafkaService kafkaService,
        IConfiguration configuration
        ) : IInputPort<UpdatePermisionRequest>
    {
        public async Task Handle(UpdatePermisionRequest request)
        {
            var Employee = employeeRepository.Get(e => e.Email == request.Email);
            var PermissionType = permissionTypeRepository.Get(e => e.PermissionTypeName == request.PermissionTypeName);

            var exist = permissionRepository.Get(e => e.EmployeeId == Employee.Id && e.PermissionTypeId == PermissionType.Id);
            if (exist == null)
            {
                throw new Exception("Permision not exists");
            }
            exist.Enable = request.Enable;
            
            permissionRepository.Update(exist);

            await elasticsearchService.UpdateDataAsync(new PermissionElastic()
            {
                Id = exist.Id,
                Email = exist.Employee.Email,
                PermissionTypeName = exist.PermissionType.PermissionTypeName,
                Enable = exist.Enable
            });

            await unitOfWork.SaveChanges();

            await kafkaService.ProducerKafkaAsync(new EventProducerKafka()
            {
                OperationName = "modify",
                OperationMessague = request
            },
            configuration["Kafka:UpdateTopic"]);
        }
    }
}
