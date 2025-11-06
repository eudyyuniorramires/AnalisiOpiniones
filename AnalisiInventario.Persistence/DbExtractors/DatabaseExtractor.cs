using AnalisiOpiniones.Application.Interfaces;
using AnalisiOpiniones.Domain.Entities.Db;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Dapper; // Se agrega la directiva para usar Dapper
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AnalisiOpniones.Persistence.DbExtractors
{
    public class DatabaseExtractor : IExtractor<OpinionDb>
    {
        private readonly string _connectionString;
        private readonly ILogger<DatabaseExtractor> _logger;

        public DatabaseExtractor(string connectionString, ILogger<DatabaseExtractor> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<List<OpinionDb>> ExtractAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Iniciando extracción de Base de Datos");

                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync(stoppingToken);

                var query = @"
                    SELECT 
                        Id,
                        ClienteNombre,
                        ClienteEmail,
                        Reseña,
                        Rating,
                        ProductoId,
                        FechaReseña,
                        Tipo
                    FROM Opiniones
                    WHERE FechaReseña >= DATEADD(DAY, -30, GETDATE())";

                // Solución al problema 1: Uso de Dapper para QueryAsync
                var result = await connection.QueryAsync<OpinionDb>(query);

                // Solución al problema 4: Manejo de nulabilidad
                var opinions = result?.ToList() ?? new List<OpinionDb>();

                // Solución a los problemas 2 y 3: Uso correcto de marcadores en LogInformation
                _logger.LogInformation("Se extrajeron {0} opiniones de la BD", opinions.Count);

                return opinions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al extraer datos de la Base de Datos");
                throw;
            }
        }
    }
}