using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;

namespace ChallengeAPI.Presenters.Permission
{
    internal class CreatePermissionPresenter : IOutputPort<CreatePermissionResponse>, IPresenter<CreatePermissionResponse>
    {
        public CreatePermissionResponse Content { get; private set; }

        public Task Handle(CreatePermissionResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
