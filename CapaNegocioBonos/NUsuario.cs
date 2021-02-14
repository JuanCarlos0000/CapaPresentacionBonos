using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using EntidadesBonos;
using CapaDatosBonos;

namespace CapaNegocioBonos
{
    public class NUsuario
    {
        #region "Procedimiento Listar usuario"
        public static DataTable Listar()
        {
            DUsuario Datos = new DUsuario();
            return Datos.Listar();
        }
        #endregion

        #region "Procedimiento Buscar usuario"
        public static DataTable Buscar(string valor)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Buscar(valor);
        }
        #endregion

        #region "Procedimiento Insertar usuario"
        public static string Insertar( string nombre, string apellidos,string usuario, string clave, string cedula)
        {
            DUsuario Datos = new DUsuario();
            Usuario Obj = new Usuario();

            string Existe = Datos.Existe(cedula);

            if (Existe.Equals("1"))
            {
                return "La persona con cedula de identidad: " + cedula + " ya está registrado.";
            }
            else
            {
                
                Obj.U_Nombre = nombre;
                Obj.U_Apellido = apellidos;
                Obj.U_Usuario = usuario;
                Obj.U_Clave = clave;
                Obj.U_Cedula = cedula;
                return Datos.Insertar(Obj);

            }
        }
        #endregion

        #region "Procedimiento Actualizar tutor"
        public static string Actualizar(int id_usuario, string cedula_anterior, string cedula, string nombre, string apellidos, string usuario, string clave)
        {
            DUsuario Datos = new DUsuario();
            Usuario Obj = new Usuario();
            if (cedula.Equals(cedula_anterior))
            {
                Obj.Id_Usuario = id_usuario;
                Obj.U_Cedula = cedula;
                Obj.U_Nombre = nombre;
                Obj.U_Apellido = apellidos;
                Obj.U_Usuario = usuario;
                Obj.U_Clave = clave;
             

                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(cedula);
                if (Existe.Equals("1"))
                {
                    return "El paciente con cedula de identidad: " + cedula + " ya está registrado.";
                }
                else
                {
                    Obj.Id_Usuario = id_usuario;
                    Obj.U_Cedula = cedula;
                    Obj.U_Nombre = nombre;
                    Obj.U_Apellido = apellidos;
                    Obj.U_Usuario = usuario;
                    Obj.U_Clave = clave;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        #endregion

        #region "Procedimiento Eliminar discapacitados"
        public static string Eliminar(int Id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Eliminar(Id);
        }
        #endregion
    }
}
