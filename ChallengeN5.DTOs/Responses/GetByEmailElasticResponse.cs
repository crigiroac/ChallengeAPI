namespace ChallengeAPI.DTOs.Responses
{
    public class GetByEmailElasticResponse
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string PermissionTypeName { get; init; }
        public bool Enable { get; init; }

    }
}
