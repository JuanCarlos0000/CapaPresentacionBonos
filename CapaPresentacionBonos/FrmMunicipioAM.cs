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
    public partial class FrmMunicipioAM : Form
    {
        public FrmMunicipioAM()
        {
            InitializeComponent();
        }

        string nombre_anterior = "";
        //Procedimientos y funciones
        private void mensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty || txtCodigo.Text == string.Empty)
                {
                    this.mensajeError("Falta datos importantes.");

                }
                else
                {
                    Rpta = NMunicipio.Insertar(txtNombre.Text.Trim(), txtCodigo.Text.Trim());
                    if (Rpta == "OK")
                    {
                        this.mensajeOK("Se registro correctamente el tipo de prueba.");
                        this.Close();
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

        private void FrmMunicipioAM_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.IdCodigoMunicipio != null)
            {
                lblModificar.Visible = true;
                txtId.Text = Convert.ToString(VariablesGlobales.IdCodigoMunicipio);
                nombre_anterior = VariablesGlobales.Mun_Nombre;
                txtNombre.Text = VariablesGlobales.Mun_Nombre;
                txtCodigo.Text = VariablesGlobales.Mun_CodMunicipio;
                btnModificar.Visible = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty || txtCodigo.Text == string.Empty)
                {
                    this.mensajeError("Falta datos importantes.");

                }
                else
                {
                    Rpta = NMunicipio.Actualizar(Convert.ToInt32(txtId.Text), nombre_anterior, txtNombre.Text.Trim(), txtCodigo.Text.Trim());
                    if (Rpta == "OK")
                    {
                        this.mensajeOK("Se modifico correctamente el tipo de prueba.");
                        this.Close();
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
    }
}
