
using System.Threading;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Application.Interfaces
{

    [cite_start]
    public interface IExtractor
    {


        [cite_start]
        Task ExtractAsync(CancellationToken stoppingToken);

    }
}
