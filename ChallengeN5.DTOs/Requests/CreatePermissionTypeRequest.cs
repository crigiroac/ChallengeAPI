namespace ChallengeAPI.DTOs.Requests
{
    public class CreatePermissionTypeRequest
    {
        public string PermissionTypeName { get; init; }
        public bool Enable { get; init; }
    }
}
