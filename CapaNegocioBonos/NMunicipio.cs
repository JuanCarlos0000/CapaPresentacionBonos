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
    public class NMunicipio
    {

        #region "Procedimiento Listar Tipo de discapacidad"
        public static DataTable Listar()
        {
            DMunicipio Datos = new DMunicipio();
            return Datos.Listar();
        }
        #endregion

        #region "Procedimiento Buscar Tipo de discapacidad"
        public static DataTable Buscar(string valor)
        {
            DMunicipio Datos = new DMunicipio();
            return Datos.Buscar(valor);
        }
        #endregion

        #region "Procedimiento Eliminar Tipo de discapacidad"
        public static string Eliminar(int Id)
        {
            DMunicipio Datos = new DMunicipio();
            return Datos.Eliminar(Id);
        }
        #endregion

        #region "Procedimiento Insertar tipo de discapacitados"
        public static string Insertar(string nombre, string codigomunicipio)
        {
            DMunicipio Datos = new DMunicipio();
            CodigoMunicipio Obj = new CodigoMunicipio();

            string Existe = Datos.Existe(nombre);

            if (Existe.Equals("1"))
            {
                return "El tipo de prueba : " + nombre + " ya está registrado.";
            }
            else
            {
                Obj.Mu_Nombre = nombre;
                Obj.Mu_CodigoMunicipio = codigomunicipio;
                return Datos.Insertar(Obj);

            }
        }
        #endregion

        #region "Procedimiento Actualizar"
        public static string Actualizar(int idCodigoMun, string nombre_anterior, string nombre, string codigomunicipal)
        {
            DMunicipio Datos = new DMunicipio();
            CodigoMunicipio Obj = new CodigoMunicipio();
            if (nombre.Equals(nombre_anterior))
            {
                Obj.IdMunicipio = idCodigoMun;
                Obj.Mu_Nombre = nombre;
                Obj.Mu_CodigoMunicipio = codigomunicipal;
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

                    Obj.IdMunicipio = idCodigoMun;
                    Obj.Mu_Nombre = nombre;
                    Obj.Mu_CodigoMunicipio = codigomunicipal;
                    return Datos.Actualizar(Obj);
                }
            }
        }
        #endregion
    }
}
