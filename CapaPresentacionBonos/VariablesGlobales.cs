using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacionBonos
{
    public class VariablesGlobales
    {

        #region "Discapacitados" 

        public static int? Id_Dicapacitados;
        public static string Nombre;
        public static string Apellidos;
        public static string Cedula;
        public static string Telefono;
        public static string Direccion;
        public static string Porcentaje;
        public static DateTime Fecha_Nac;
        public static DateTime Venc_Carnet;
        public static string Genero;
        public static string Registro;
        public static DateTime Venc_Carnet_Disc; 
        
        #endregion

        #region "Tutor"
        public static int? Id_Tutor;
        public static string t_Nombre;
        public static string t_Apellidos;
        public static string t_cedula;
        public static DateTime t_fecha_nacimiento;
        public static string t_Direccion;
        public static string t_Genero;
        public static string t_Telefono;
        public static string t_Parantesco;

        #endregion

        #region "Usuario"
        public static int? Id_Usuario;
        public static string U_Nombre;
        public static string U_Apellidos;
        public static string U_cedula;
        public static string U_Usuario;
        public static string U_Clave;
        #endregion

        #region "Tipo de discapacidad"
        public static int? ID_TipoDiscapacidad;
        public static string Ti_Nombre;
        #endregion

        #region "Codigo Municipio"
        public static int? IdCodigoMunicipio;
        public static string Mun_Nombre;
        public static string Mun_CodMunicipio;
        #endregion

    }
}
