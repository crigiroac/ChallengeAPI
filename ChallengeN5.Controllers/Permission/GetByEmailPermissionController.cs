using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Presenters;
using ChallengeAPI.UseCases.Common;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers.Permission
{
    public class GetByEmailPermissionController (IInputPort<GetByEmailPermissionRequest> inputPort,
        IOutputPort<IEnumerable<GetByEmailElasticResponse>> outputPort): ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GetByEmailElasticResponse>> GetByEmailPermission(GetByEmailPermissionRequest request)
        {
            await inputPort.Handle(request);
            return ((IPresenter<IEnumerable<GetByEmailElasticResponse>>)outputPort).Content;
        }
    }
}
