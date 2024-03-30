namespace ChallengeAPI.DTOs.Responses
{
    public class GetEmployeePermissionResponse
    {
        public Guid PermissionTypeId { get; init; }
        public bool Enable { get; init; }
    }

}
