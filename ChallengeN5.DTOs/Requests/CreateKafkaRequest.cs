namespace ChallengeAPI.DTOs.Requests
{
    public class CreateKafkaRequest
    {
        public Guid Id { get; set; }
        public string OperationName  { get; set; }
        public Object OperationMessague { get; set; }
        public CreateKafkaRequest()
        {
            Id = Guid.NewGuid();
        }
    }
}
