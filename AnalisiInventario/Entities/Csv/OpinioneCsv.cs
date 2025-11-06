using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Domain.Entities.Csv
{
    public class OpinioneCsv
    {

        public string ClienteNombre { get; set; } = string.Empty;
        public string ClienteEmail { get; set; } = string.Empty;
        public string Opinion { get; set; } = string.Empty;
        public int Calificacion { get; set; }
        public string ProductoNombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Clasificacion { get; set; } = string.Empty;
    }
}
