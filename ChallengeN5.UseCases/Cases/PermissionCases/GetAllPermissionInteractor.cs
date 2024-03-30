using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Kafka;
using ChallengeAPI.UseCases.Common;
using System.Text.Json;

namespace ChallengeAPI.UseCases.Cases.PermissionCases
{
    internal class GetAllPermissionInteractor(
        IPermissionRepository permissionRepository,
        IOutputPort<IEnumerable<GetPermissionResponse>> outputPort,
        KafkaService kafkaService
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

            CreateKafkaRequest createKafkaRequest = new()
            {
                OperationName = "get",
                OperationMessague = request
            };
            await kafkaService.GetBuilder(createKafkaRequest.Id.ToString(), JsonSerializer.Serialize(createKafkaRequest));
        }
    }
}
