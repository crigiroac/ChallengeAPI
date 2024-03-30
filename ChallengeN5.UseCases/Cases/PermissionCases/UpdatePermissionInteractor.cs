using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.Elasticsearch;
using ChallengeAPI.Kafka;
using ChallengeAPI.UseCases.Common;
using System.Text.Json;

namespace ChallengeAPI.UseCases.Cases.PermissionCases
{
    internal class UpdatePermissionInteractor(IPermissionRepository permissionRepository,
        IUnitOfWork unitOfWork,
        IEmployeeRepository employeeRepository,
        IPermissionTypeRepository permissionTypeRepository,
        ElasticsearchService elasticsearchService,
        KafkaService kafkaService
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

            await unitOfWork.SaveChanges();

            CreateKafkaRequest createKafkaRequest = new()
            {
                OperationName = "modify",
                OperationMessague = request
            };

            await kafkaService.UpdateBuilder(createKafkaRequest.Id.ToString(), JsonSerializer.Serialize(createKafkaRequest));

            await elasticsearchService.UpdateDataAsync(new UpdatePermisionRequest() {
                Id = exist.Id,
                Email = exist.Employee.Email,
                PermissionTypeName = exist.PermissionType.PermissionTypeName,
                Enable = exist.Enable
            });


        }
    }
}
