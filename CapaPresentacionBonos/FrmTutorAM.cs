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
    public partial class FrmTutorAM : Form
    {
        public FrmTutorAM()
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
        private string devolverGenero()
        {
            if (rbFemenino.Checked)
            {
                return "Femenino";
            }
            else
            {
                return "Masculino";
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
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

                    if (dtNacimiento.Value > DateTime.Now)
                    {
                        this.mensajeError("La fecha de nacimiento es incorrecta.");
                    }
                    else
                    {
                        if (!rbFemenino.Checked && !rbMasculino.Checked)
                        {
                            this.mensajeError("Por favor seleccione un género para el paciente.");
                        }
                        else
                        {
                            Rpta = Ntutor.Insertar(txtCedula.Text.Trim(), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), txtTelefono.Text.Trim(), txtDireccion.Text.Trim(), dtNacimiento.Value, txtParentesco.Text.Trim(), devolverGenero());
                            if (Rpta == "OK")
                            {
                                this.mensajeOK("Se registro correctamente el paciente.");
                                this.Close();
                            }
                            else
                            {
                                this.mensajeError(Rpta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmTutorAM_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.Id_Tutor != null)
            {
                lblModificar.Visible = true;
                txtId.Text = Convert.ToString(VariablesGlobales.Id_Tutor);
                txtNombres.Text = VariablesGlobales.t_Nombre;
                txtApellidos.Text = VariablesGlobales.t_Apellidos;
                cedula_anterior = VariablesGlobales.t_cedula;
                txtCedula.Text = VariablesGlobales.t_cedula;
                dtNacimiento.Value = VariablesGlobales.t_fecha_nacimiento;
                txtDireccion.Text = VariablesGlobales.t_Direccion;
                txtTelefono.Text = VariablesGlobales.t_Telefono;
                txtParentesco.Text = VariablesGlobales.t_Parantesco;
                btnModificar.Visible = true;

                if (VariablesGlobales.t_Genero == "Femenino")
                {
                    rbFemenino.Checked = true;
                }
                else
                {
                    rbMasculino.Checked = true;
                }

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
                if (txtNombres.Text == string.Empty || txtApellidos.Text == string.Empty || txtCedula.Text == string.Empty)
                {
                    this.mensajeError("Falta datos importantes.");

                }
                else
                {
                    Rpta = Ntutor.Actualizar(Convert.ToInt32(txtId.Text), cedula_anterior, txtCedula.Text.Trim(), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), txtTelefono.Text.Trim(), txtDireccion.Text.Trim(), dtNacimiento.Value,  devolverGenero(), txtParentesco.Text.Trim());
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
    }
}
