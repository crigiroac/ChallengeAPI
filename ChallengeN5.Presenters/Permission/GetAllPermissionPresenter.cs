using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;

namespace ChallengeAPI.Presenters.Permission
{
    internal class GetAllPermissionPresenter : IOutputPort<IEnumerable<GetPermissionResponse>>, IPresenter<IEnumerable<GetPermissionResponse>>
    {
        public IEnumerable<GetPermissionResponse> Content { get; private set; }
        public Task Handle(IEnumerable<GetPermissionResponse> response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
