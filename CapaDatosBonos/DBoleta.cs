using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//librerias para Sql Server
using System.Data;
using System.Data.SqlClient;
//refenrencia con la clase EntidadBonos
using EntidadesBonos;

namespace CapaDatosBonos
{
    public class DBoleta
    {
        #region "Insertar Boleta"
        public string Insertar(Boleta Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("boleta_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = Obj.Id_Persona;
                Comando.Parameters.Add("@IdTutor", SqlDbType.Int).Value = Obj.Id_Tutor;
                Comando.Parameters.Add("@FechaCobro", SqlDbType.Date).Value = Obj.Fecha_Cobro;
                Comando.Parameters.Add("@MesDeCobro", SqlDbType.Date).Value = Obj.Mes_Cobro;
                Comando.Parameters.Add("@Monto", SqlDbType.Int).Value = Obj.Monto;
                Comando.Parameters.Add("@IdMunicipio", SqlDbType.Int).Value = Obj.Id_Municipio;
                Comando.Parameters.Add("@IdTipoDisc", SqlDbType.Int).Value = Obj.Id_TipoDisc;

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

    }
}
