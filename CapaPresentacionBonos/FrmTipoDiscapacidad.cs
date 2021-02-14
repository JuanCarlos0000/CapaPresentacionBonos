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
    public partial class FrmTipoDiscapacidad : Form
    {
        public FrmTipoDiscapacidad()
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
            dgvListado.Columns[2].Visible = false;
            ////Ancho de las columna
            dgvListado.Columns[1].Width = 100;
            ////titulo d las columnas
            dgvListado.Columns[1].HeaderText = "TIPO DE DISCAPACIDAD";
        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NTipoDiscapacidad.Listar();
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
                dgvListado.DataSource = NTipoDiscapacidad.Buscar(txtBuscar.Text);
                this.formato();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.ID_TipoDiscapacidad = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdTipoDisc"].Value);
            VariablesGlobales.Ti_Nombre = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);

            FrmTipoDiscapacidadAM frm = new FrmTipoDiscapacidadAM();
            frm.FormClosed += new FormClosedEventHandler(FrmTipoDiscapacidad_FormClosed);
            frm.ShowDialog();
        }

        private void FrmTipoDiscapacidad_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdTipoDisc"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro de la persona: \"" + nombre + "\"?", "Sistema Laboratorio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    Rpta = NTipoDiscapacidad.Eliminar(id);

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
        private void FrmTipoDiscapacidad_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.ID_TipoDiscapacidad = null;
            this.Listar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmTipoDiscapacidadAM frm = new FrmTipoDiscapacidadAM();
            frm.FormClosed += new FormClosedEventHandler(FrmTipoDiscapacidad_FormClosed);
            frm.ShowDialog();
        }

        
    }
}
