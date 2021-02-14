using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


using EntidadesBonos;
using CapaDatosBonos;

namespace CapaNegocioBonos
{
    public class NTipoDiscapacidad
    {
        #region "Procedimiento Listar Tipo de discapacidad"
        public static DataTable Listar()
        {
            DTipoDiscapacidad Datos = new DTipoDiscapacidad();
            return Datos.Listar();
        }
        #endregion

        #region "Procedimiento Buscar Tipo de discapacidad"
        public static DataTable Buscar(string valor)
        {
            DTipoDiscapacidad Datos = new DTipoDiscapacidad();
            return Datos.Buscar(valor);
        }
        #endregion

        #region "Procedimiento Eliminar Tipo de discapacidad"
        public static string Eliminar(int Id)
        {
            DTipoDiscapacidad Datos = new DTipoDiscapacidad();
            return Datos.Eliminar(Id);
        }
        #endregion

        #region "Procedimiento Insertar tipo de discapacitados"
        public static string Insertar(string nombre)
        {
            DTipoDiscapacidad Datos = new DTipoDiscapacidad();
            TipoDiscapacidad Obj = new TipoDiscapacidad();

            string Existe = Datos.Existe(nombre);

            if (Existe.Equals("1"))
            {
                return "El tipo de prueba : " + nombre + " ya está registrado.";
            }
            else
            {
                Obj.Ti_Nombre = nombre;
                return Datos.Insertar(Obj);

            }
        }
        #endregion

        #region "Procedimiento Actualizar"
        public static string Actualizar(int idTipoDisc, string nombre_anterior, string nombre)
        {
            DTipoDiscapacidad Datos = new DTipoDiscapacidad();
            TipoDiscapacidad Obj = new TipoDiscapacidad();
            if (nombre.Equals(nombre_anterior))
            {
                Obj.Id_Tipo_Disc = idTipoDisc;
                Obj.Ti_Nombre = nombre;
                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(nombre);
                if (Existe.Equals("1"))
                {
                    return "El tipo de prueba : " + nombre + " ya está registrado.";
                }
                else
                {

                    Obj.Id_Tipo_Disc = idTipoDisc;
                    Obj.Ti_Nombre = nombre;
                    return Datos.Actualizar(Obj);
                }
            }
        }
        #endregion
    }
}
