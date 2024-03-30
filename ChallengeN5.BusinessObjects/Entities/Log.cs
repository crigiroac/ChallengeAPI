namespace ChallengeAPI.BusinessObjects.Entities
{
    public class Log : EntityBase
    {
        public string OperationType { get; set; }
        public string OperationRequest { get; set; }
        public string OperarionResponse { get; set; }
        public string OperationStatus { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }

    }
}
