namespace ChallengeAPI.BusinessObjects.Entities
{
    public class EventProducerKafka
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OperationName { get; set; }
        public Object OperationMessague { get; set; }
       
    }
}
