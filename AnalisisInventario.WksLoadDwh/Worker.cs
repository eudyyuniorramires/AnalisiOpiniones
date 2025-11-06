using Microsoft.Extensions.Logging;
using AnalisiOpiniones.Application.Interfaces;
using AnalisiOpiniones.Domain.Entities.Csv;
using AnalisiOpiniones.Domain.Entities.Db;
using AnalisiOpiniones.Domain.Entities.Api;

namespace AnalisisInventario.WksLoadDwh
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IExtractor<OpinioneCsv> _csvExtractor;
        private readonly IExtractor<OpinionDb> _dbExtractor;
        private readonly IExtractor<OpinionApi> _apiExtractor;

        public Worker(
            ILogger<Worker> logger,
            IExtractor<OpinioneCsv> csvExtractor,
            IExtractor<OpinionDb> dbExtractor,
            IExtractor<OpinionApi> apiExtractor)
        {
            _logger = logger;
            _csvExtractor = csvExtractor;
            _dbExtractor = dbExtractor;
            _apiExtractor = apiExtractor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Iniciando proceso ETL en: {time}", DateTimeOffset.Now);

                    // Extracción paralela de las 3 fuentes
                    var csvTask = _csvExtractor.ExtractAsync(stoppingToken);
                    var dbTask = _dbExtractor.ExtractAsync(stoppingToken);
                    var apiTask = _apiExtractor.ExtractAsync(stoppingToken);

                    await Task.WhenAll(csvTask, dbTask, apiTask);

                    var csvOpinions = csvTask.Result;
                    var dbOpinions = dbTask.Result;
                    var apiOpinions = apiTask.Result;

                    _logger.LogInformation(
                        "Extracción completada - CSV: {CsvCount}, DB: {DbCount}, API: {ApiCount}",
                        csvOpinions.Count, dbOpinions.Count, apiOpinions.Count);

                    // TODO: Aquí agregarás la transformación y carga (T y L del ETL)

                    // Ejecutar cada 1 hora
                    await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en el proceso ETL");
                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                }
            }
        }
    }
}
