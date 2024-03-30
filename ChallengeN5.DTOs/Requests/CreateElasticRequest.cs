namespace ChallengeAPI.DTOs.Requests
{
    public class CreateElasticRequest
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string PermissionTypeName { get; init; }
        public bool Enable { get; init; }
    }
}
