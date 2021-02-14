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
    public partial class FrmDiscapacitadosAM : Form
    {
        public FrmDiscapacitadosAM()
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

        private void FrmDiscapacitadosAM_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.Id_Dicapacitados != null)
            {
                lblModificar.Visible = true;
                txtId.Text = Convert.ToString(VariablesGlobales.Id_Dicapacitados);
                txtNombre.Text = VariablesGlobales.Nombre;
                txtApellidos.Text = VariablesGlobales.Apellidos;
                cedula_anterior = VariablesGlobales.Cedula;
                txtCedula.Text = VariablesGlobales.Cedula;
                txtTelefono.Text = VariablesGlobales.Telefono;
                txtDireccion.Text = VariablesGlobales.Direccion;
                txtPorcentaje.Text = VariablesGlobales.Porcentaje;
                dtNacimiento.Value = VariablesGlobales.Fecha_Nac;
                dtVencimiento.Value = VariablesGlobales.Venc_Carnet;
                txtRegistro.Text = VariablesGlobales.Registro;
                dtVenceDiscapacidad.Value = VariablesGlobales.Venc_Carnet_Disc;
                btnModificar.Visible = true;

                if (VariablesGlobales.Genero == "Femenino")
                {
                    rbFemenino.Checked = true;
                }
                else
                {
                    rbMasculino.Checked = true;
                }
                
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty || txtApellidos.Text == string.Empty || txtCedula.Text == string.Empty)
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
                            Rpta = NDiscapacitados.Insertar(txtCedula.Text.Trim(), txtNombre.Text.Trim(), txtApellidos.Text.Trim(), txtTelefono.Text.Trim(), txtDireccion.Text.Trim(), txtPorcentaje.Text.Trim(), dtNacimiento.Value, dtVencimiento.Value, txtRegistro.Text.Trim(), dtVenceDiscapacidad.Value, devolverGenero());
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

        private void txtId_TextChanged(object sender, EventArgs e)
        {

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
                if (txtNombre.Text == string.Empty || txtApellidos.Text == string.Empty || txtCedula.Text == string.Empty)
                {
                    this.mensajeError("Falta datos importantes.");

                }
                else
                {
                    Rpta = NDiscapacitados.Actualizar(Convert.ToInt32(txtId.Text), cedula_anterior, txtCedula.Text.Trim(), txtNombre.Text.Trim(), txtApellidos.Text.Trim(), txtTelefono.Text.Trim(), txtDireccion.Text.Trim(), txtPorcentaje.Text.Trim(), dtNacimiento.Value, dtVencimiento.Value, txtRegistro.Text.Trim(), devolverGenero(), dtVenceDiscapacidad.Value);
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
