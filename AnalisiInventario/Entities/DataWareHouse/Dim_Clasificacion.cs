using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Domain.Entities.DataWareHouse
{
    public class Dim_Clasificacion
    {
        public int ClasificacionID { get; set; }
        public string Sentimiento { get; set; }
    }
}
