using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Domain.Entities.Api
{


    public class OpinionApiResponse
    {
        public List<OpinionApi> Reviews { get; set; } = new();
    }

    public class OpinionApi
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Score { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
