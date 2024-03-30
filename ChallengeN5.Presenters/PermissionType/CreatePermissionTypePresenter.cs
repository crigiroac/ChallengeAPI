using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;

namespace ChallengeAPI.Presenters.PermissionType
{
    internal class CreatePermissionTypePresenter : IOutputPort<CreatePermissionTypeResponse>, IPresenter<CreatePermissionTypeResponse>
    {
        public CreatePermissionTypeResponse Content { get; private set; }

        public Task Handle(CreatePermissionTypeResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
