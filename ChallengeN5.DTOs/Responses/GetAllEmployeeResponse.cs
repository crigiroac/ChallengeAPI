namespace ChallengeAPI.DTOs.Responses
{
    public class GetAllEmployeeResponse
    {

        public IEnumerable<EmployeeReposponse> Employees { get; init; }
    }


    public class EmployeeReposponse {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
