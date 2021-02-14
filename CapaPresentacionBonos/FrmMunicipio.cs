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
    public partial class FrmMunicipio : Form
    {
        public FrmMunicipio()
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
            ////Ancho de las columna
            dgvListado.Columns[1].Width = 100;
            dgvListado.Columns[2].Width = 80;
            ////titulo d las columnas
            dgvListado.Columns[1].HeaderText = "NOMBRE";
            dgvListado.Columns[2].HeaderText = "CODIGO MUNICIPIO";

        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NMunicipio.Listar();
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
                dgvListado.DataSource = NMunicipio.Buscar(txtBuscar.Text);
                this.formato();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }

        private void FrmMunicipio_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.IdCodigoMunicipio = null;
            this.Listar();
        }

        private void FrmMunicipio_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdMun"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro de la persona: \"" + nombre + "\"?", "Sistema Laboratorio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    Rpta = NMunicipio.Eliminar(id);

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmMunicipioAM frm = new FrmMunicipioAM();
            frm.FormClosed += new FormClosedEventHandler(FrmMunicipio_FormClosed);
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.IdCodigoMunicipio = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdMun"].Value);
            VariablesGlobales.Mun_Nombre = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            VariablesGlobales.Mun_CodMunicipio = Convert.ToString(dgvListado.CurrentRow.Cells["CodigoMun"].Value);

            FrmMunicipioAM frm = new FrmMunicipioAM();
            frm.FormClosed += new FormClosedEventHandler(FrmMunicipio_FormClosed);
            frm.ShowDialog();
        }
    }
}
