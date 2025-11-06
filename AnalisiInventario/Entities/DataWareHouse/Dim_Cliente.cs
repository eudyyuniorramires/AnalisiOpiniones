using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Domain.Entities.DataWareHouse
{
    public class Dim_Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
