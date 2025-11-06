using AnalisiOpiniones.Application.Interfaces;
using AnalisiOpiniones.Domain.Entities.Csv;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using System;

using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOpniones.Persistence.CvExtractors
{
    public class CsvExtractor : IExtractor<OpinioneCsv>
    {
        private readonly string _filePath;
        private readonly ILogger<CsvExtractor> _logger;

        public CsvExtractor(string filePath, ILogger<CsvExtractor> logger)
        {
            _filePath = filePath;
            _logger = logger;
        }

        public async Task<List<OpinioneCsv>> ExtractAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Iniciando extracción de CSV desde: {FilePath}", _filePath);

                if (!File.Exists(_filePath))
                {
                    _logger.LogError("Archivo CSV no encontrado: {FilePath}", _filePath);
                    return new List<OpinioneCsv>();
                }

                using var reader = new StreamReader(_filePath);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ",",
                };

                using var csv = new CsvReader(reader, config);
                var records = csv.GetRecords<OpinioneCsv>().ToList();

                _logger.LogInformation("Se extrajeron {Count} opiniones del CSV", records.Count);
                return await Task.FromResult(records);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al extraer datos del CSV");
                throw;
            }
        }
    }
}
