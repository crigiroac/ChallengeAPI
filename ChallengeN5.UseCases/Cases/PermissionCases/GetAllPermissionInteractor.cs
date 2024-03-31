using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.BusinessObjects.IServices;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Kafka;
using ChallengeAPI.UseCases.Common;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ChallengeAPI.UseCases.Cases.PermissionCases
{
    internal class GetAllPermissionInteractor(
        IPermissionRepository permissionRepository,
        IOutputPort<IEnumerable<GetPermissionResponse>> outputPort,
        IKafkaService kafkaService,
        IConfiguration configuration
        ) : IInputPort<IGetAllPermissionRequest>
    {
        
        public async Task Handle(IGetAllPermissionRequest request)
        {
            var permissions = permissionRepository.GetPermissionsDetail()
                .Select(e => new GetPermissionResponse() { 
                    Id = e.Id,
                    Name = e.Employee.Name,
                    PermissionTypeName= e.PermissionType.PermissionTypeName,
                    Enable =e.Enable
                });

            await outputPort.Handle(permissions);

           
            await kafkaService.ProducerKafkaAsync(new EventProducerKafka()
            {
                OperationName = "get",
                OperationMessague = request
            },
            configuration["Kafka:GetTopic"]);
        }
    }
}
