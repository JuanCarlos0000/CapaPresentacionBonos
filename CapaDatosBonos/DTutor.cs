using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
//refenrencia con la clase EntidadBonos
using EntidadesBonos;

namespace CapaDatosBonos
{
    public class DTutor
    {
        #region "Listar Tutor"
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("tutor_listar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        #endregion

        #region " Buscar Tutor"
        public DataTable Buscar(string valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("tutor_buscar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

        }
        #endregion

        #region "Insertar Tutor"
        public string Insertar(Tutor Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("tutor_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.T_nombres;
                Comando.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = Obj.T_Apellidos;
                Comando.Parameters.Add("@cedula", SqlDbType.VarChar).Value = Obj.T_cedula;
                Comando.Parameters.Add("@fechaNac", SqlDbType.Date).Value = Obj.T_fecha_Nac;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = Obj.T_Direccion;
                Comando.Parameters.Add("@genero", SqlDbType.VarChar).Value = Obj.T_Genero;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.T_Telefono;
                Comando.Parameters.Add("@parentesco", SqlDbType.VarChar).Value = Obj.T_Parentesco;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        #endregion

        #region "Existe Discapacitados"
        public string Existe(string valor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("tutor_existe", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ParExiste);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(ParExiste.Value);
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        #endregion

        #region "Eliminar Tutor"
        public string Eliminar(int Idtutor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("tutor_eliminar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdTutor", SqlDbType.Int).Value = Idtutor;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro.";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        #endregion

        #region "Actualizar usuario"
        public string Actualizar(Tutor Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("tutor_actualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdTutor", SqlDbType.Int).Value = Obj.Id_Tutor;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.T_nombres;
                Comando.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Obj.T_Apellidos;
                Comando.Parameters.Add("@Cedula", SqlDbType.VarChar).Value = Obj.T_cedula;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.T_Telefono;
                Comando.Parameters.Add("@FechaNac", SqlDbType.Date).Value = Obj.T_fecha_Nac;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.T_Direccion;
                Comando.Parameters.Add("@Genero", SqlDbType.VarChar).Value = Obj.T_Genero;
                Comando.Parameters.Add("@Parentesco", SqlDbType.VarChar).Value = Obj.T_Parentesco;
                
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        #endregion

    }
}
