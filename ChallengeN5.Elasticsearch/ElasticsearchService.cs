using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IServices;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Configuration;

namespace ChallengeAPI.Elasticsearch
{
    public class ElasticsearchService : IElasticsearchService
    {
        private readonly ElasticsearchClient _client;

        public ElasticsearchService(IConfiguration configuration)
        {
            var settings = new ElasticsearchClientSettings(new Uri(configuration["ElasticsearchService:Server"].ToString()))
            .CertificateFingerprint(configuration["ElasticsearchService:CertificateFingerprint"])
            .Authentication(new BasicAuthentication(configuration["ElasticsearchService:Authentication:User"], configuration["ElasticsearchService:Authentication:Password"]));
            _client = new ElasticsearchClient(settings);
        }

        public async Task IndexDataFromSqlAsync(PermissionElastic permissionElastic)
        {
            var indexResponse = await _client.IndexAsync(permissionElastic, "challenge_n5"); // Indexar en Elasticsearch
            if (!indexResponse.IsValidResponse)
            {
                // Manejar errores si la indexación falla
                Console.WriteLine($"Error al indexar documento: {indexResponse.DebugInformation}");
            }
            if (indexResponse.IsValidResponse)
            {
                Console.WriteLine($"Index document with ID {indexResponse.Id} succeeded.");
            }
        }
        public async Task UpdateDataAsync(PermissionElastic permissionElastic)
        {

            var indexResponse = await _client.UpdateAsync<PermissionElastic, PermissionElastic>(
                "challenge_n5",
                permissionElastic.Id,
                e => e.Doc(permissionElastic)
                );
            if (!indexResponse.IsValidResponse)
            {
                // Manejar errores si la indexación falla
                Console.WriteLine($"Error al indexar documento: {indexResponse.DebugInformation}");
            }
            if (indexResponse.IsValidResponse)
            {
                Console.WriteLine($"Index document with ID {indexResponse.Id} succeeded.");
            }
        }
        public async Task<IEnumerable<PermissionElastic>> GetByEmailDataAsync(string email)
        {
            IEnumerable<PermissionElastic> result = null;


            //var requestElastic = new SearchRequest("challenge_n5")
            //{
            //    From = 0,
            //    Size = 10,
            //    Query = new TermQuery("email") { Value = request.Email }
            //};
            //var indexResponse = await _client.SearchAsync<GetByEmailElasticResponse>(requestElastic);

            var indexResponse = await _client.SearchAsync<PermissionElastic>(
                e => e
                    .Index("challenge_n5")
                    .From(0)
                    .Size(20)
                    .Query(q => q
                        .MatchPhrase( m =>m
                            .Field(f => f.Email.Suffix("keyword"))
                            .Query(email)
                        )
                ));

            if (indexResponse.IsValidResponse)
            {
                result = (IEnumerable<PermissionElastic>) indexResponse.Documents;
            }

            return result;
        }
    }
}
