using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IServices;
using ChallengeAPI.DTOs.Requests;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ChallengeAPI.Kafka
{
    public class KafkaService : IKafkaService
    {
        private readonly ProducerConfig _client;
        public KafkaService(IConfiguration configuration) {
            _client = new ProducerConfig{
                BootstrapServers = configuration["Kafka:Server"]
            };
        }
        public async Task ProducerKafkaAsync(EventProducerKafka eventProducerKafka, string topic)
        {
            using (var producerRequest = new ProducerBuilder<string, string>(_client).Build())
            {
                await producerRequest.ProduceAsync(
                    topic,
                    new Message<string, string> { Key = eventProducerKafka.Id.ToString(), Value = JsonSerializer.Serialize(eventProducerKafka) }
                    );
            }
        }
    }
}
