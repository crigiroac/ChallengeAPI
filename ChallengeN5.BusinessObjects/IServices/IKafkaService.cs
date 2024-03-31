using ChallengeAPI.BusinessObjects.Entities;

namespace ChallengeAPI.BusinessObjects.IServices
{
    public interface IKafkaService
    {
        Task ProducerKafkaAsync(EventProducerKafka eventProducerKafka, string topic);
    }
}
