using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//libreria
using System.Data;

using EntidadesBonos;
using CapaDatosBonos;

namespace CapaNegocioBonos
{
    public class NBoleta
    {

        #region "Procedimiento Insertar Boleta"
        public static string Insertar(int IdPersona, int IdTutor, DateTime FechaCobro, DateTime MesCobro, int Monto, int IdMunicipio, int IdTipoDisc)
        {
            DBoleta Datos = new DBoleta();
            Boleta Obj = new Boleta();
            Obj.Id_Persona = IdPersona;
            Obj.Id_Tutor = IdTutor;
            Obj.Fecha_Cobro = FechaCobro;
            Obj.Mes_Cobro = MesCobro;
            Obj.Monto = Monto;
            Obj.Id_Municipio = IdMunicipio;
            Obj.Id_TipoDisc = IdTipoDisc;
            return Datos.Insertar(Obj);
        }
        #endregion

    }
}
