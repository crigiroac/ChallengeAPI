using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Presenters;
using ChallengeAPI.UseCases.Common;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers.Permission
{
    public class CreatePermissionController(IInputPort<CreatePermissionRequest> inputPort, IOutputPort<CreatePermissionResponse> outputPort): ApiControllerBase
    {
        [HttpPost]
        public async Task<CreatePermissionResponse> CreatePermission(CreatePermissionRequest request) { 
            await inputPort.Handle(request);
            return ((IPresenter<CreatePermissionResponse>)outputPort).Content;
        }
    }
}
