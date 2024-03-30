using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Presenters;
using ChallengeAPI.UseCases.Common;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers.PermissionType
{
    public class CreatePermissionType(IInputPort<CreatePermissionTypeRequest> inputPort, IOutputPort<CreatePermissionTypeResponse> outputPort): ApiControllerBase
    {
        [HttpPost]
        public async Task<CreatePermissionTypeResponse> CreatePermisionType(CreatePermissionTypeRequest request) { 
            await inputPort.Handle(request);
            return ((IPresenter<CreatePermissionTypeResponse>)outputPort).Content;
        }
    }
}
