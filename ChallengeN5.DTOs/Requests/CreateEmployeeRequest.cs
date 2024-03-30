namespace ChallengeAPI.DTOs.Requests
{
    public class CreateEmployeeRequest
    {
        public string Name { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
    }
}
