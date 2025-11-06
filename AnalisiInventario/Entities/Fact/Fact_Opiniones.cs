using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Domain.Entities.Fact
{
    public class Fact_Opiniones
    {
        public int OpinionID { get; set; }
        public int TiempoID { get; set; }
        public int ProductoID { get; set; }
        public int ClienteID { get; set; }
        public int FuenteID { get; set; }
        public int ClasificacionID { get; set; }

        /// <summary>
        /// Métrica: Puntaje 1-5
        /// </summary>
        public int PuntajeSatisfaccion { get; set; }

        /// <summary>
        /// Métrica: Siempre es 1
        /// </summary>
        public int ConteoComentario { get; set; }
    }
}
