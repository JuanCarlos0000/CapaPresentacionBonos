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
    public partial class FrmDiscapacitados : Form
    {
        public FrmDiscapacitados()
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


            //Ancho de las columnas
            dgvListado.Columns[1].Width = 100;
            dgvListado.Columns[2].Width = 100;
            dgvListado.Columns[4].Width = 60;
            dgvListado.Columns[5].Width = 70;
            dgvListado.Columns[6].Width = 70;
            dgvListado.Columns[9].Width = 70;
            dgvListado.Columns[10].Width = 70;
            dgvListado.Columns[11].Width = 70;
            dgvListado.Columns[12].Width = 70;

            //titulo d las columnas
            dgvListado.Columns[1].HeaderText = "NOMBRE";
            dgvListado.Columns[2].HeaderText = "APELLIDOS";
            dgvListado.Columns[4].HeaderText = "CEDULA";
            dgvListado.Columns[5].HeaderText = "TELEFONO";
            dgvListado.Columns[6].HeaderText = "DIRECCION";
            dgvListado.Columns[7].HeaderText = " % DE DISCAPACIDAD";
            dgvListado.Columns[8].HeaderText = "FECHA DE NACIMIENTO";
            dgvListado.Columns[9].HeaderText = "VENCIMIENTO CARNET";
            dgvListado.Columns[10].HeaderText = "GENERO";
            dgvListado.Columns[11].HeaderText = "REGISTRO";
            dgvListado.Columns[12].HeaderText = "VENC. CARNET DISCAPACIDAD";
        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NDiscapacitados.Listar();
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
                dgvListado.DataSource = NDiscapacitados.Buscar(txtBuscar.Text);
                this.formato();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }



        private void FrmDiscapacitados_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void FrmDiscapacitados_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.Id_Dicapacitados = null;
            this.Listar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmDiscapacitadosAM frm = new FrmDiscapacitadosAM();
            frm.FormClosed += new FormClosedEventHandler(FrmDiscapacitados_FormClosed);
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.Id_Dicapacitados = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdPersona"].Value);
            VariablesGlobales.Nombre = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            VariablesGlobales.Apellidos = Convert.ToString(dgvListado.CurrentRow.Cells["Apellidos"].Value);
            VariablesGlobales.Cedula = Convert.ToString(dgvListado.CurrentRow.Cells["Cedula"].Value);
            VariablesGlobales.Telefono = Convert.ToString(dgvListado.CurrentRow.Cells["Telefono"].Value);
            VariablesGlobales.Direccion = Convert.ToString(dgvListado.CurrentRow.Cells["Direccion"].Value);
            VariablesGlobales.Porcentaje = Convert.ToString(dgvListado.CurrentRow.Cells["PorcentajeDisc"].Value);
            VariablesGlobales.Fecha_Nac = Convert.ToDateTime(dgvListado.CurrentRow.Cells["FechaNac"].Value);
            VariablesGlobales.Venc_Carnet = Convert.ToDateTime(dgvListado.CurrentRow.Cells["VencCarnet"].Value);
            VariablesGlobales.Genero = Convert.ToString(dgvListado.CurrentRow.Cells["Genero"].Value);
            VariablesGlobales.Registro = Convert.ToString(dgvListado.CurrentRow.Cells["Registro"].Value);
            VariablesGlobales.Venc_Carnet_Disc = Convert.ToDateTime(dgvListado.CurrentRow.Cells["VencCarnetDisc"].Value);

            FrmDiscapacitadosAM frm = new FrmDiscapacitadosAM();
            frm.FormClosed += new FormClosedEventHandler(FrmDiscapacitados_FormClosed);
            frm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdPersona"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value);
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro de la persona: \"" + nombre + "\"?", "Sistema Laboratorio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    Rpta = NDiscapacitados.Eliminar(id);

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

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
