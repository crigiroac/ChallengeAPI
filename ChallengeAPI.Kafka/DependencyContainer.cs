using ChallengeAPI.BusinessObjects.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeAPI.Kafka
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddKafka (this IServiceCollection services, IConfiguration IKafkaService) {
            
            services.AddScoped<IKafkaService, KafkaService>();

            return services;
        }
    }
}
