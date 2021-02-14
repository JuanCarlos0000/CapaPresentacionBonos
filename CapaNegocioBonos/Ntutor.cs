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
    public class Ntutor
    {

        #region "Procedimiento Listar discapacitados"
        public static DataTable Listar()
        {
            DTutor Datos = new DTutor();
            return Datos.Listar();
        }
        #endregion

        #region "Procedimiento Buscar discapacitados"
        public static DataTable Buscar(string valor)
        {
            DTutor Datos = new DTutor();
            return Datos.Buscar(valor);
        }
        #endregion

        #region "Procedimiento Insertar tutor"
        public static string Insertar(string cedula, string nombre, string apellidos, string telefono, string direccion, DateTime fechaNac, string parentesco, string genero)
        {
            DTutor Datos = new DTutor();
            Tutor Obj = new Tutor();

            string Existe = Datos.Existe(cedula);

            if (Existe.Equals("1"))
            {
                return "La persona con cedula de identidad: " + cedula + " ya está registrado.";
            }
            else
            {
                Obj.T_cedula = cedula;
                Obj.T_nombres = nombre;
                Obj.T_Apellidos = apellidos;
                Obj.T_Telefono = telefono;
                Obj.T_Direccion = direccion;
                Obj.T_fecha_Nac = fechaNac;
                Obj.T_Parentesco = parentesco;
                Obj.T_Genero = genero;
                return Datos.Insertar(Obj);

            }
        }


        #endregion

        #region "Procedimiento Eliminar tutor"
        public static string Eliminar(int Id)
        {
            DTutor Datos = new DTutor();
            return Datos.Eliminar(Id);
        }
        #endregion

        #region "Procedimiento Actualizar tutor"
        public static string Actualizar(int id_tutor, string cedula_anterior, string cedula, string nombre, string apellidos, string telefono, string direccion, DateTime fecha_nac, string genero, string parentesco)
        {
            DTutor Datos = new DTutor();
            Tutor Obj = new Tutor();
            if (cedula.Equals(cedula_anterior))
            {
                Obj.Id_Tutor = id_tutor;
                Obj.T_cedula = cedula;
                Obj.T_nombres = nombre;
                Obj.T_Apellidos = apellidos;
                Obj.T_Telefono = telefono;
                Obj.T_Direccion = direccion;
                Obj.T_fecha_Nac = fecha_nac;
                Obj.T_Genero = genero;
                Obj.T_Parentesco = parentesco;
      
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
                    Obj.Id_Tutor = id_tutor;
                    Obj.T_nombres = nombre;
                    Obj.T_Apellidos = apellidos;
                    Obj.T_cedula = cedula;
                    Obj.T_Telefono = telefono;
                    Obj.T_Direccion = direccion;
                    Obj.T_fecha_Nac = fecha_nac;
                    Obj.T_Genero = genero;
                    Obj.T_Parentesco = parentesco;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        #endregion
    }
}
