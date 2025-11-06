using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Domain.Entities.DataWareHouse
{
    public class Dim_Tiempo
    {
        public int TiempoID { get; set; }
        public DateTime Fecha { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public string Trimestre { get; set; }
        public string NombreMes { get; set; } // Asumido basado en el corte de la imagen
    }
}
