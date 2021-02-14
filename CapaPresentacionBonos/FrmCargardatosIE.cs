using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocioBonos;

namespace CapaPresentacionBonos
{
    public partial class FrmCargardatosIE : Form
    {
        public FrmCargardatosIE()
        {
            InitializeComponent();
        }

        private static FrmCargardatosIE _instancia;
        public static FrmCargardatosIE DevolverInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmCargardatosIE();
            }
            return _instancia;
        }
        private void mensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Laboratorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Laboratorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmCargardatosIE_Load(object sender, EventArgs e)
        {
                      
                txtIdD.Text = Convert.ToString(VariablesGlobales.Id_Dicapacitados);
                txtIdT.Text = Convert.ToString(VariablesGlobales.Id_Tutor);
                txtIdTd.Text = Convert.ToString(VariablesGlobales.ID_TipoDiscapacidad);
                txtIdM.Text = Convert.ToString(VariablesGlobales.IdCodigoMunicipio);
                txtRegistro.Text = VariablesGlobales.Registro;
                txtNombred.Text = VariablesGlobales.Nombre;
                txtApellidod.Text = VariablesGlobales.Apellidos;
                txtCedulad.Text = VariablesGlobales.Cedula;       
                dtNacimiento.Value = VariablesGlobales.Fecha_Nac;
                dtVencimiento.Value = VariablesGlobales.Venc_Carnet_Disc;
                txtDireccion.Text = VariablesGlobales.Direccion;
                txtNombret.Text = VariablesGlobales.t_Nombre;
                txtCedulat.Text = VariablesGlobales.t_cedula;
                txtDiscapacidad.Text = VariablesGlobales.Ti_Nombre;
                txtPorcentaje.Text = VariablesGlobales.Porcentaje;
                txtNombreM.Text = VariablesGlobales.Mun_Nombre;
                txtCodigo.Text = VariablesGlobales.Mun_CodMunicipio;

                //txtMonto.Text = "250";
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombred.Text == string.Empty || txtNombret.Text == string.Empty)
                {
                    this.mensajeError("Falta datos importantes.");

                }
                else
                {
                    Rpta = NBoleta.Insertar(Convert.ToInt32(txtIdD.Text), Convert.ToInt32(txtIdT.Text), dtMesCobro.Value, dtFechaHoy.Value, Convert.ToInt32(txtMonto.Text), Convert.ToInt32(txtIdM.Text), Convert.ToInt32(txtIdTd.Text));
                    if (Rpta == "OK")
                    {
                        this.mensajeOK("Se registro correctamente, el examen se encuentra pendiente.");
                    }
                    else
                    {
                        this.mensajeError(Rpta);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtIdD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
