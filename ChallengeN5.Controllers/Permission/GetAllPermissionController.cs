using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Presenters;
using ChallengeAPI.UseCases.Common;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers.Permission
{
    public class GetAllPermissionController(IInputPort<IGetAllPermissionRequest> inputPort, IOutputPort<IEnumerable<GetPermissionResponse>> outputPort) : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GetPermissionResponse>> GetAllPermission() {
            await inputPort.Handle(null);
            return ((IPresenter<IEnumerable<GetPermissionResponse>>)outputPort).Content;
        }
    }
}
