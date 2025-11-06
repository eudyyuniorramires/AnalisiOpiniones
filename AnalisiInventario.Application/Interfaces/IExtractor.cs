
using System.Threading;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Application.Interfaces
{

    public interface IExtractor<T> where T : class
    {

       Task<List<T>> ExtractAsync(CancellationToken stoppingToken);

    }
}
