using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Domain.Entities.Db
{
    public class OpinionDb
    {
        public int Id { get; set; }
        public string ClienteNombre { get; set; } = string.Empty;
        public string ClienteEmail { get; set; } = string.Empty;
        public string Reseña { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string ProductoId { get; set; } = string.Empty;
        public DateTime FechaReseña { get; set; }
        public string Tipo { get; set; } = string.Empty;
    }
}
