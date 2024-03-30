using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;
using System.Globalization;

namespace ChallengeAPI.UseCases.Cases
{
    internal class CreatePermisionTypeInteractor(IPermissionTypeRepository permissionTypeRepository,
       IOutputPort<CreatePermissionTypeResponse> outputPort,
       IUnitOfWork unitOfWork) : IInputPort<CreatePermissionTypeRequest>
    {
        public async Task Handle(CreatePermissionTypeRequest request)
        {
            PermissionType newPermisionType = new();

            var exists = permissionTypeRepository.Get(e => e.PermissionTypeName == request.PermissionTypeName);
            if (exists != null) {
                throw new Exception("PermisionType exists");
            }
            
            newPermisionType.PermissionTypeName = request.PermissionTypeName;

            permissionTypeRepository.Add(newPermisionType);

            await unitOfWork.SaveChanges();

            await outputPort.Handle(
                new CreatePermissionTypeResponse() { 
                    Id=newPermisionType.Id,
                    PermissionTypeName = newPermisionType.PermissionTypeName
                });
        }
    }
}
