using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;

namespace ChallengeAPI.Presenters.Permission
{
    internal class GetByEmailPermissionElasticPresenter : IOutputPort<IEnumerable<GetByEmailElasticResponse>>,
        IPresenter<IEnumerable<GetByEmailElasticResponse>>
    {
        public IEnumerable<GetByEmailElasticResponse> Content { get; private set; }
        public Task Handle(IEnumerable<GetByEmailElasticResponse> response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
