using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBonos
{
    public class Discapacitados
    {
        public int Id_Discapacitados { get; set; }
        public int Id_Tutor { get; set; }
        public int Id_Examen { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }

        public string Direccion { get; set; }
        public string PorcentajeDisc { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public DateTime Venc_Carnet { get; set; }
        public string Genero { get; set; }
        public string Registro { get; set; }
        public DateTime Venc_Carnet_Disc { get; set; }
        

    }


  
}
