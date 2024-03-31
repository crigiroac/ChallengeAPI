using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;

namespace ChallengeAPI.Presenters.Permission
{
    internal class GetByEmailPermissionElasticPresenter : IOutputPort<IEnumerable<PermissionElasticResponse>>,
        IPresenter<IEnumerable<PermissionElasticResponse>>
    {
        public IEnumerable<PermissionElasticResponse> Content { get; private set; }
        public Task Handle(IEnumerable<PermissionElasticResponse> response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
