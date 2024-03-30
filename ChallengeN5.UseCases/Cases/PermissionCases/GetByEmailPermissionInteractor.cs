using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Elasticsearch;
using ChallengeAPI.Kafka;
using ChallengeAPI.UseCases.Common;
using System.Text.Json;

namespace ChallengeAPI.UseCases.Cases.PermissionCases
{
    internal class GetByEmailPermissionInteractor(IPermissionRepository permissionRepository,
        IOutputPort<IEnumerable<GetByEmailElasticResponse>> outputPort,
        KafkaService kafkaService, 
        ElasticsearchService elasticsearchService
        ) : IInputPort<GetByEmailPermissionRequest>
    {
        public async Task Handle(GetByEmailPermissionRequest request)
        {

            var permissions = elasticsearchService.GetByEmailDataAsync(request).Result;


            //var permissions = permissionRepository.GetByEmailPermissionsDetail(request.Email)
            //    .Select(e => new GetPermissionResponse()
            //    {
            //        Id = e.Id,
            //        Name = e.Employee.Name,
            //        PermissionTypeName = e.PermissionType.PermissionTypeName,
            //        Enable = e.Enable
            //    });

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
