using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace ChallengeAPI.Kafka
{
    public class KafkaService
    {
        private ProducerConfig _client;
        private string _createTopic;
        private string _updateTopic;
        private string _getTopic;
        public KafkaService(IConfiguration configuration) {
            _client = new ProducerConfig{
                BootstrapServers = configuration["Kafka:Server"]
            };
            _createTopic = configuration["Kafka:CreateTopic"];
            _updateTopic = configuration["Kafka:UpdateTopic"];
            _getTopic = configuration["Kafka:GetTopic"];

        }

        public async Task ProducerBuilder(string _key, string _object ) { 
            using( var producerRequest = new ProducerBuilder<string,string>(_client).Build() )
            {

                await producerRequest.ProduceAsync(
                    _createTopic,
                    new Message<string, string> { Key = _key, Value = _object }
                    );

            }
        }
        public async Task UpdateBuilder(string _key, string _object)
        {
            using (var producerRequest = new ProducerBuilder<string, string>(_client).Build())
            {
                await producerRequest.ProduceAsync(
                    _updateTopic,
                    new Message<string, string> { Key = _key, Value = _object }
                    );
            }
        }
        public async Task GetBuilder(string _key, string _object)
        {
            using (var producerRequest = new ProducerBuilder<string, string>(_client).Build())
            {
                var resultSend = await producerRequest.ProduceAsync(
                    _getTopic,
                    new Message<string, string> { Key = _key, Value = _object }
                    );
            }
        }


    }
}
