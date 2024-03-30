using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeAPI.Kafka
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddKafka (this IServiceCollection services, IConfiguration configuration) {
            
            services.AddScoped<KafkaService>();

            return services;
        }
    }
}
