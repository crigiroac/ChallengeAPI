namespace ChallengeAPI.DTOs.Requests
{
    public class CreatePermissionRequest
    {
        //public Guid EmployeeId { get; init; }
        //public Guid PermissionTypeId { get; init; }
        public string Email { get; init; }
        public string PermissionTypeName { get; init; }
        public bool Enable { get; init; }
    }
}
