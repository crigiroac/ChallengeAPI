namespace ChallengeAPI.DTOs.Responses
{
    public class GetAllPermisionTypeResponse
    {
        IEnumerable<PermisionTypeResponse> PermisionTypes { get; init; }
    }

    public class PermisionTypeResponse
    {

        public Guid Id { get; init; }
        public string PermissionTypeName { get; init; }
    }
}
