using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBonos
{
    public class Boleta
    {

        public int Id_Persona { get; set; }
        public int Id_Tutor { get; set; }
        public DateTime Fecha_Cobro { get; set; }
        public DateTime Mes_Cobro { get; set; }
        public int Monto { get; set; }
        public int Id_Municipio { get; set; }
        public int Id_TipoDisc { get; set; }
       

    }
}
