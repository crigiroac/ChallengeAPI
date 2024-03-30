using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace ChallengeAPI.Elasticsearch
{
    public class ElasticsearchService
    {
        private readonly ElasticsearchClient _client;

        public ElasticsearchService(IConfiguration configuration)
        {
            var settings = new ElasticsearchClientSettings(new Uri(configuration["ElasticsearchService:Server"].ToString()))
            .CertificateFingerprint(configuration["ElasticsearchService:CertificateFingerprint"])
            .Authentication(new BasicAuthentication(configuration["ElasticsearchService:Authentication:User"], configuration["ElasticsearchService:Authentication:Password"]));

            _client = new ElasticsearchClient(settings);
        }

        public async Task IndexDataFromSqlAsync(CreateElasticRequest permission)
        {
            var indexResponse = await _client.IndexAsync(permission, "challenge_n5"); // Indexar en Elasticsearch
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
        public async Task UpdateDataAsync(UpdatePermisionRequest updatePermisionRequest)
        {

            var indexResponse = await _client.UpdateAsync<UpdatePermisionRequest, UpdatePermisionRequest>(
                "challenge_n5",
                updatePermisionRequest.Id,
                e => e.Doc(updatePermisionRequest)
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
        public async Task<IEnumerable<GetByEmailElasticResponse>> GetByEmailDataAsync(GetByEmailPermissionRequest request)
        {
            IEnumerable<GetByEmailElasticResponse> result = null;


            //var requestElastic = new SearchRequest("challenge_n5")
            //{
            //    From = 0,
            //    Size = 10,
            //    Query = new TermQuery("email") { Value = request.Email }
            //};
            //var indexResponse = await _client.SearchAsync<GetByEmailElasticResponse>(requestElastic);

            var indexResponse = await _client.SearchAsync<GetByEmailElasticResponse>(
                e => e
                    .Index("challenge_n5")
                    .From(0)
                    .Size(20)
                    .Query(q => q
                        .Match( m =>m
                            .Field(f => f.Email)
                            .Query(request.Email)
                        //.Term(t => t.Email, request.Email)
                        )
                ));

            if (indexResponse.IsValidResponse)
            {
                result = (IEnumerable<GetByEmailElasticResponse>) indexResponse.Documents;
            }

            return result;
        }
    }
}
