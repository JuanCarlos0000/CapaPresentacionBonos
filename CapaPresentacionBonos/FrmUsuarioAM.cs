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
    public partial class FrmUsuarioAM : Form
    {
        public FrmUsuarioAM()
        {
            InitializeComponent();
        }

         string cedula_anterior = "";
        //Procedimientos y funciones
        private void mensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmUsuarioAM_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.Id_Usuario != null)
            {
                lblModificar.Visible = true;
                txtId.Text = Convert.ToString(VariablesGlobales.Id_Usuario);
                txtNombres.Text = VariablesGlobales.U_Nombre;
                txtApellidos.Text = VariablesGlobales.U_Apellidos;
                cedula_anterior = VariablesGlobales.U_cedula;
                txtCedula.Text = VariablesGlobales.U_cedula;
                txtUsuario.Text = VariablesGlobales.U_Usuario;
                txtClave.Text = VariablesGlobales.U_Clave;             
                btnModificar.Visible = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombres.Text == string.Empty || txtApellidos.Text == string.Empty || txtCedula.Text == string.Empty || txtUsuario.Text == string.Empty || txtClave.Text == string.Empty)
                {
                    this.mensajeError("Falta datos importantes.");

                }
                else
                {
                    Rpta = NUsuario.Insertar( txtNombres.Text.Trim(), txtApellidos.Text.Trim(), txtUsuario.Text.Trim(), txtClave.Text.Trim(),txtCedula.Text.Trim());
                    if (Rpta == "OK")
                    {
                        this.mensajeOK("Se registro correctamente el usuario.");
                  
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombres.Text == string.Empty || txtApellidos.Text == string.Empty || txtCedula.Text == string.Empty)
                {
                    this.mensajeError("Falta datos importantes.");

                }
                else
                {
                    Rpta = NUsuario.Actualizar(Convert.ToInt32(txtId.Text), cedula_anterior, txtCedula.Text.Trim(), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), txtUsuario.Text.Trim(), txtClave.Text.Trim());
                    if (Rpta == "OK")
                    {
                        this.mensajeOK("Se modificaron correctamente los datos.");

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
