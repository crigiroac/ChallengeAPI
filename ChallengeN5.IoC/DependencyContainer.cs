using Microsoft.Extensions.DependencyInjection;
using ChallengeAPI.RepositoryEFCore;
using Microsoft.Extensions.Configuration;
using ChallengeAPI.UseCases;
using ChallengeAPI.Presenters;
using ChallengeAPI.Elasticsearch;
using ChallengeAPI.Kafka;



namespace ChallengeAPI.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddChallengeDependencies (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCasesServices();
            services.AddPresenters();
            services.AddRepositoriesElasticsearch(configuration);
            services.AddKafka(configuration);

            return services;
        }
    }
}
