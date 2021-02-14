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
    public class NDiscapacitados
    {

        #region "Procedimiento Listar discapacitados"
        public static DataTable Listar()
        {
            DDiscapacitados Datos = new DDiscapacitados();
            return Datos.Listar();
        }
        #endregion

        #region "Procedimiento Buscar discapacitados"
        public static DataTable Buscar(string valor)
        {
            DDiscapacitados Datos = new DDiscapacitados();
            return Datos.Buscar(valor);
        }
        #endregion

        #region "Procedimiento Insertar discapacitados"
        public static string Insertar(string cedula, string nombre, string apellidos, string telefono, string direccion, string porcentajeDisc, DateTime fechaNac, DateTime vencCarnet, string registro, DateTime vencCarnetDisc, string genero)
        {
            DDiscapacitados Datos = new DDiscapacitados();
            Discapacitados Obj = new Discapacitados();

            string Existe = Datos.Existe(cedula);

            if (Existe.Equals("1"))
            {
                return "La persona con cedula de identidad: " + cedula + " ya está registrado.";
            }
            else
            {
                Obj.Cedula = cedula;
                Obj.Nombre = nombre;
                Obj.Apellidos = apellidos;
                Obj.Telefono = telefono;
                Obj.Direccion = direccion;
                Obj.PorcentajeDisc = porcentajeDisc;
                Obj.Fecha_Nac = fechaNac;
                Obj.Venc_Carnet = vencCarnet;
                Obj.Registro = registro;
                Obj.Genero = genero;
                Obj.Venc_Carnet_Disc = vencCarnetDisc;
                return Datos.Insertar(Obj);

            }
        }


        #endregion

        #region "Procedimiento Eliminar discapacitados"
        public static string Eliminar(int Id)
        {
            DDiscapacitados Datos = new DDiscapacitados();
            return Datos.Eliminar(Id);
        }
        #endregion

        #region "Procedimiento Actualizar"
        public static string Actualizar(int id_discapacitado, string cedula_anterior, string cedula, string nombre, string apellidos, string telefono, string direccion, string porcentaje, DateTime fecha_nac, DateTime vencCarnet, string registro, string genero, DateTime vencCarnetDisc)
        {
            DDiscapacitados Datos = new DDiscapacitados();
            Discapacitados Obj = new Discapacitados();
            if (cedula.Equals(cedula_anterior))
            {
                Obj.Id_Discapacitados = id_discapacitado;
                Obj.Cedula = cedula;
                Obj.Nombre = nombre;
                Obj.Apellidos = apellidos;
                Obj.Telefono = telefono;
                Obj.Direccion = direccion;
                Obj.PorcentajeDisc = porcentaje;
                Obj.Fecha_Nac = fecha_nac;
                Obj.Venc_Carnet = vencCarnet;
                Obj.Genero = genero;
                Obj.Registro = registro;
                Obj.Venc_Carnet_Disc = vencCarnetDisc;
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
                    Obj.Id_Discapacitados = id_discapacitado;
                    
                    Obj.Nombre = nombre;
                    Obj.Apellidos = apellidos;
                    Obj.Cedula = cedula;
                    Obj.Telefono = telefono;
                    Obj.Direccion = direccion;
                    Obj.PorcentajeDisc = porcentaje;
                    Obj.Fecha_Nac = fecha_nac;
                    Obj.Venc_Carnet = vencCarnet;
                    Obj.Genero = genero;
                    Obj.Registro = registro;
                    Obj.Venc_Carnet_Disc = vencCarnetDisc;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        #endregion

        #region "Procedimiento listar Cargardatos"
        public static DataTable ListarDatos()
        {
            DDiscapacitados Datos = new DDiscapacitados();
            return Datos.ListarDatos();
        }
        #endregion

        #region "Procedimiento Buscar discapacitados"
        public static DataTable BuscarDatos(string valor)
        {
            DDiscapacitados Datos = new DDiscapacitados();
            return Datos.BuscarDatos(valor);
        }
        #endregion



    }
}
