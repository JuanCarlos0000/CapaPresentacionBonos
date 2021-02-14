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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void mensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formato()
        {
            //ocultar columnas
            dgvListado.Columns[0].Visible = false;
            dgvListado.Columns[3].Visible = false;
            dgvListado.Columns[5].Visible = false;

            //Ancho de las columnas
            dgvListado.Columns[1].Width = 100;
            dgvListado.Columns[2].Width = 100;
            dgvListado.Columns[4].Width = 70;
            dgvListado.Columns[6].Width = 70;

            //titulo d las columnas
            dgvListado.Columns[1].HeaderText = "NOMBRE";
            dgvListado.Columns[2].HeaderText = "APELLIDOS";
            dgvListado.Columns[4].HeaderText = "USUARIO";
            dgvListado.Columns[6].HeaderText = "CEDULA";

        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NUsuario.Listar();
                this.formato();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }

        private void Buscar()
        {
            try
            {
                dgvListado.DataSource = NUsuario.Buscar(txtBuscar.Text);
                this.formato();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }
        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void FrmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.Id_Usuario = null;
            this.Listar();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmUsuarioAM frm = new FrmUsuarioAM();
            frm.FormClosed += new FormClosedEventHandler(FrmUsuario_FormClosed);
            frm.ShowDialog();
        }

        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.Id_Usuario = Convert.ToInt32(dgvListado.CurrentRow.Cells["idUsuario"].Value);
            VariablesGlobales.U_Nombre = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            VariablesGlobales.U_Apellidos = Convert.ToString(dgvListado.CurrentRow.Cells["apellido"].Value);
            VariablesGlobales.U_cedula = Convert.ToString(dgvListado.CurrentRow.Cells["cedula"].Value);
            VariablesGlobales.U_Usuario = Convert.ToString(dgvListado.CurrentRow.Cells["Usuario"].Value);
            VariablesGlobales.U_Clave = Convert.ToString(dgvListado.CurrentRow.Cells["clave"].Value);

            FrmUsuarioAM frm = new FrmUsuarioAM();
            frm.FormClosed += new FormClosedEventHandler(FrmUsuario_FormClosed);
            frm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdUsuario"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro de la persona: \"" + nombre + "\"?", "Sistema Laboratorio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    Rpta = NUsuario.Eliminar(id);

                    if (Rpta == "OK")
                    {
                        this.mensajeOk("Se elimino el registro.");
                        this.Listar();
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
