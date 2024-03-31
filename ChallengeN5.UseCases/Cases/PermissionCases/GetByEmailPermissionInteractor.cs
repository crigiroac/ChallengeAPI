using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IServices;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;
using Microsoft.Extensions.Configuration;

namespace ChallengeAPI.UseCases.Cases.PermissionCases
{
    internal class GetByEmailPermissionInteractor(
        //IPermissionRepository permissionRepository,
        IOutputPort<IEnumerable<PermissionElasticResponse>> outputPort,
        IKafkaService kafkaService,
        IConfiguration configuration,
        IElasticsearchService elasticsearchService
        ) : IInputPort<GetByEmailPermissionRequest>
    {
        public async Task Handle(GetByEmailPermissionRequest request)
        {
            var permissions = await elasticsearchService.GetByEmailDataAsync(request.Email);

            //var permissions = permissionRepository.GetByEmailPermissionsDetail(request.Email)
            //    .Select(e => new GetPermissionResponse()
            //    {
            //        Id = e.Id,
            //        Name = e.Employee.Name,
            //        PermissionTypeName = e.PermissionType.PermissionTypeName,
            //        Enable = e.Enable
            //    });

            
            await kafkaService.ProducerKafkaAsync(new EventProducerKafka(){
                OperationName = "get",
                OperationMessague = request},
             configuration["Kafka:GetTopic"]);


            await outputPort.Handle(permissions.Select(e=> new PermissionElasticResponse() { 
                Id = e.Id,
                Email= e.Email,
                Enable = e.Enable,
                PermissionTypeName = e.PermissionTypeName
            } ));


        }
    }
}
