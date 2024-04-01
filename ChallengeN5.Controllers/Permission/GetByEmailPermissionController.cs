using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Presenters;
using ChallengeAPI.UseCases.Common;
using Elastic.Clients.Elasticsearch.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers.Permission
{
    public class GetByEmailPermissionController (IInputPort<GetByEmailPermissionRequest> inputPort,
        IOutputPort<IEnumerable<PermissionElasticResponse>> outputPort): ApiControllerBase
    {
        [HttpGet("{email}")]
        public async Task<IEnumerable<PermissionElasticResponse>> GetByEmailPermission(string email)
        {
            await inputPort.Handle(new() {Email= email});
            return ((IPresenter<IEnumerable<PermissionElasticResponse>>)outputPort).Content;
        }
    }
}
