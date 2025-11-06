using AnalisiOpiniones.Application.Interfaces;
using AnalisiOpiniones.Domain.Entities.Api;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnalisiOpniones.Persistence.ApiExtractors
{
    public class ApiExtractor : IExtractor<OpinionApi>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ApiExtractor> _logger;
        private readonly string _apiUrl;

        public ApiExtractor(IHttpClientFactory httpClientFactory, string apiUrl, ILogger<ApiExtractor> logger)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
            _logger = logger;
        }

        public async Task<List<OpinionApi>> ExtractAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Iniciando extracción de API: {ApiUrl}", _apiUrl);

                var client = _httpClientFactory.CreateClient();
                client.Timeout = TimeSpan.FromSeconds(30);

                var response = await client.GetAsync(_apiUrl, stoppingToken);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync(stoppingToken);
                var apiResponse = JsonSerializer.Deserialize<OpinionApiResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var opinions = apiResponse?.Reviews ?? new List<OpinionApi>();

                _logger.LogInformation("Se extrajeron {Count} opiniones de la API", opinions.Count);
                return opinions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al extraer datos de la API");
                throw;
            }
        }
    }
}
