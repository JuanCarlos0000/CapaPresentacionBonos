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
    public partial class FrmTutor : Form
    {
        public FrmTutor()
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
            dgvListado.Columns[10].Visible = false;

            //Ancho de las columnas
            dgvListado.Columns[1].Width = 100;
            dgvListado.Columns[2].Width = 100;
            dgvListado.Columns[3].Width = 70;
            dgvListado.Columns[4].Width = 60;
            dgvListado.Columns[5].Width = 90;
            dgvListado.Columns[9].Width = 90;
            dgvListado.Columns[10].Width = 70;

            //titulo d las columnas
            dgvListado.Columns[1].HeaderText = "NOMBRE";
            dgvListado.Columns[2].HeaderText = "APELLIDOS";
            dgvListado.Columns[4].HeaderText = "CEDULA";
            dgvListado.Columns[5].HeaderText = "FECHA DE NACIMIENTO";
            dgvListado.Columns[6].HeaderText = "DIRECCION";
            dgvListado.Columns[7].HeaderText = "GENERO";
            dgvListado.Columns[8].HeaderText = "TELEFONO";
            dgvListado.Columns[9].HeaderText = "PARENTESCO";

        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = Ntutor.Listar();
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
                dgvListado.DataSource = Ntutor.Buscar(txtBuscar.Text);
                this.formato();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }
        private void FrmTutor_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void FrmTutor_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.Id_Tutor = null;
            this.Listar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmTutorAM frm = new FrmTutorAM();
            frm.FormClosed += new FormClosedEventHandler(FrmTutor_FormClosed);
            frm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdTutor"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value);
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro de la persona: \"" + nombre + "\"?", "Sistema Laboratorio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    Rpta = Ntutor.Eliminar(id);

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.Id_Tutor = Convert.ToInt32(dgvListado.CurrentRow.Cells["idTutor"].Value);
            VariablesGlobales.t_Nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value);
            VariablesGlobales.t_Apellidos = Convert.ToString(dgvListado.CurrentRow.Cells["apellidos"].Value);
            VariablesGlobales.t_cedula = Convert.ToString(dgvListado.CurrentRow.Cells["cedula"].Value);
            VariablesGlobales.t_fecha_nacimiento = Convert.ToDateTime(dgvListado.CurrentRow.Cells["FechaNac"].Value);
            VariablesGlobales.t_Direccion = Convert.ToString(dgvListado.CurrentRow.Cells["Direccion"].Value);
            VariablesGlobales.t_Telefono = Convert.ToString(dgvListado.CurrentRow.Cells["telefono"].Value);          
            VariablesGlobales.t_Parantesco = Convert.ToString(dgvListado.CurrentRow.Cells["Parentesco"].Value);
            VariablesGlobales.t_Genero = Convert.ToString(dgvListado.CurrentRow.Cells["Genero"].Value);

            FrmTutorAM frm = new FrmTutorAM();
            frm.FormClosed += new FormClosedEventHandler(FrmTutor_FormClosed);
            frm.ShowDialog();
        }
    }
}
