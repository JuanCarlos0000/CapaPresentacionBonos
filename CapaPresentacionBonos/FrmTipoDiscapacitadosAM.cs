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
    public partial class FrmTipoDiscapacidadAM : Form
    {
        public FrmTipoDiscapacidadAM()
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
                if (txtNombre.Text == string.Empty)
                {
                    this.mensajeError("Falta datos importantes.");

                }
                else
                {
                    Rpta = NTipoDiscapacidad.Insertar(txtNombre.Text.Trim());
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

        private void FrmTipoDiscapacidadAM_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.ID_TipoDiscapacidad != null)
            {
                lblModificar.Visible = true;
                txtId.Text = Convert.ToString(VariablesGlobales.ID_TipoDiscapacidad);
                nombre_anterior = VariablesGlobales.Ti_Nombre;
                txtNombre.Text = VariablesGlobales.Ti_Nombre;
                btnModificar.Visible = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty)
                {
                    this.mensajeError("Falta datos importantes.");

                }
                else
                {
                    Rpta = NTipoDiscapacidad.Actualizar(Convert.ToInt32(txtId.Text), nombre_anterior, txtNombre.Text.Trim());
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
