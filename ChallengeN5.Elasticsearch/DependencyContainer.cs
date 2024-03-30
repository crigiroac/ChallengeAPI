﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeAPI.Elasticsearch
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositoriesElasticsearch (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ElasticsearchService>();

            return services;
        }
    }
}
