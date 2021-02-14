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
    public partial class FrmCargardatos : Form
    {
        public FrmCargardatos()
        {
            InitializeComponent();
        }
        private static FrmCargardatosIE _instancia;
        public static FrmCargardatosIE DevolverInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmCargardatosIE();
            }
            return _instancia;
        }
        private void mensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formato1()
        {
            //ocultar columnas
            dgvListado1.Columns[0].Visible = false;
            dgvListado1.Columns[3].Visible = false;
   
            //Ancho de las columnas
            dgvListado1.Columns[1].Width = 100;
            dgvListado1.Columns[2].Width = 100;
            dgvListado1.Columns[4].Width = 60;
            dgvListado1.Columns[5].Width = 70;
            dgvListado1.Columns[6].Width = 70;
            dgvListado1.Columns[9].Width = 70;
            dgvListado1.Columns[10].Width = 70;
            dgvListado1.Columns[11].Width = 70;
            dgvListado1.Columns[12].Width = 70;

            //titulo d las columnas
            dgvListado1.Columns[1].HeaderText = "NOMBRE";
            dgvListado1.Columns[2].HeaderText = "APELLIDOS";
            dgvListado1.Columns[4].HeaderText = "CEDULA";
            dgvListado1.Columns[5].HeaderText = "TELEFONO";
            dgvListado1.Columns[6].HeaderText = "DIRECCION";
            dgvListado1.Columns[7].HeaderText = " % DE DISCAPACIDAD";
            dgvListado1.Columns[8].HeaderText = "FECHA DE NACIMIENTO";
            dgvListado1.Columns[9].HeaderText = "VENCIMIENTO CARNET";
            dgvListado1.Columns[10].HeaderText = "GENERO";
            dgvListado1.Columns[11].HeaderText = "REGISTRO";
            dgvListado1.Columns[12].HeaderText = "VENC. CARNET DISCAPACIDAD";
        }

        private void formato2()
        {
            //ocultar columnas
            dgvListado2.Columns[0].Visible = false;
            dgvListado2.Columns[3].Visible = false;
            dgvListado2.Columns[10].Visible = false;

            //Ancho de las columnas
            dgvListado2.Columns[1].Width = 100;
            dgvListado2.Columns[2].Width = 100;
            dgvListado2.Columns[3].Width = 70;
            dgvListado2.Columns[4].Width = 60;
            dgvListado2.Columns[5].Width = 90;
            dgvListado2.Columns[9].Width = 90;
            dgvListado2.Columns[10].Width = 70;

            //titulo d las columnas
            dgvListado2.Columns[1].HeaderText = "NOMBRE";
            dgvListado2.Columns[2].HeaderText = "APELLIDOS";
            dgvListado2.Columns[4].HeaderText = "CEDULA";
            dgvListado2.Columns[5].HeaderText = "FECHA DE NACIMIENTO";
            dgvListado2.Columns[6].HeaderText = "DIRECCION";
            dgvListado2.Columns[7].HeaderText = "GENERO";
            dgvListado2.Columns[8].HeaderText = "TELEFONO";
            dgvListado2.Columns[9].HeaderText = "PARENTESCO";

        }

        private void formato3()
        {
            //ocultar columnas
            dgvListado3.Columns[0].Visible = false;
            dgvListado3.Columns[2].Visible = false;
            ////Ancho de las columna
            dgvListado3.Columns[1].Width = 100;
            ////titulo d las columnas
            dgvListado3.Columns[1].HeaderText = "TIPO DE DISCAPACIDAD";
        }

        private void formato4()
        {
            //ocultar columnas
            dgvListado4.Columns[0].Visible = false;
            dgvListado4.Columns[3].Visible = false;
            ////Ancho de las columna
            dgvListado4.Columns[1].Width = 100;
            dgvListado4.Columns[2].Width = 80;
            ////titulo d las columnas
            dgvListado4.Columns[1].HeaderText = "NOMBRE";
            dgvListado4.Columns[2].HeaderText = "CODIGO MUNICIPIO";
        }

        private void Listar1()
        {
            try
            {
                dgvListado1.DataSource = NDiscapacitados.Listar();
                this.formato1();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }

        private void Listar2()
        {
            try
            {
                dgvListado2.DataSource = Ntutor.Listar();
                this.formato2();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }

        private void Listar3()
        {
            try
            {
                dgvListado3.DataSource = NTipoDiscapacidad.Listar();
                this.formato3();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }

        private void Listar4()
        {
            try
            {
                dgvListado4.DataSource = NMunicipio.Listar();
                this.formato4();
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
                dgvListado1.DataSource = NDiscapacitados.Buscar(txtBuscar.Text);
                this.formato1();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }

        private void Buscar2()
        {
            try
            {
                dgvListado2.DataSource = Ntutor.Buscar(txtBuscar2.Text);
                this.formato2();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }
        private void Buscar3()
        {
            try
            {
                dgvListado3.DataSource = NTipoDiscapacidad.Buscar(txtBuscar3.Text);
                this.formato3();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }

        private void Buscar4()
        {
            try
            {
                dgvListado4.DataSource = NMunicipio.Buscar(txtBuscar4.Text);
                this.formato4();
            }
            catch (Exception ex)
            {

                mensajeError(ex.Message);
            }
        }

        private void FrmCargardatos_Load(object sender, EventArgs e)
        {
            this.Listar1();
            this.Listar2();
            this.Listar3();
            this.Listar4();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
           
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VariablesGlobales.Id_Dicapacitados = Convert.ToInt32(dgvListado1.CurrentRow.Cells["idPersona"].Value);
            VariablesGlobales.Registro = Convert.ToString(dgvListado1.CurrentRow.Cells["Registro"].Value);
            VariablesGlobales.Nombre = Convert.ToString(dgvListado1.CurrentRow.Cells["Nombre"].Value);
            VariablesGlobales.Apellidos = Convert.ToString(dgvListado1.CurrentRow.Cells["Apellidos"].Value);
            VariablesGlobales.Cedula = Convert.ToString(dgvListado1.CurrentRow.Cells["Cedula"].Value);
            VariablesGlobales.Fecha_Nac = Convert.ToDateTime(dgvListado1.CurrentRow.Cells["FechaNac"].Value);
            VariablesGlobales.Venc_Carnet_Disc = Convert.ToDateTime(dgvListado1.CurrentRow.Cells["VencCarnetDisc"].Value);
            VariablesGlobales.Direccion = Convert.ToString(dgvListado1.CurrentRow.Cells["Direccion"].Value);
            VariablesGlobales.Porcentaje = Convert.ToString(dgvListado1.CurrentRow.Cells["PorcentajeDisc"].Value);

            FrmCargardatosIE frm = new FrmCargardatosIE();
            frm.FormClosed += new FormClosedEventHandler(FrmCargardatos_FormClosed);
            frm.ShowDialog();

            //this.Close();


        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmCargardatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
        }

        private void txtBuscar2_TextChanged(object sender, EventArgs e)
        {
            this.Buscar2();
        }

        private void txtBuscar3_TextChanged(object sender, EventArgs e)
        {
            this.Buscar3();
        }

        private void txtBuscar4_TextChanged(object sender, EventArgs e)
        {
            this.Buscar4();
        }

        private void dgvListado1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgvListado2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VariablesGlobales.t_Nombre = Convert.ToString(dgvListado2.CurrentRow.Cells["nombre1"].Value);
            VariablesGlobales.t_cedula = Convert.ToString(dgvListado2.CurrentRow.Cells["cedula"].Value);

            FrmCargardatosIE frm = new FrmCargardatosIE();
            frm.FormClosed += new FormClosedEventHandler(FrmCargardatos_FormClosed);
            frm.ShowDialog();
        }

        private void dgvListado3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VariablesGlobales.Ti_Nombre = Convert.ToString(dgvListado3.CurrentRow.Cells["Nombre"].Value);
            FrmCargardatosIE frm = new FrmCargardatosIE();
            frm.FormClosed += new FormClosedEventHandler(FrmCargardatos_FormClosed);
            frm.ShowDialog();
        }

        private void dgvListado4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VariablesGlobales.Mun_Nombre = Convert.ToString(dgvListado4.CurrentRow.Cells["nombre"].Value);
            VariablesGlobales.Mun_CodMunicipio = Convert.ToString(dgvListado4.CurrentRow.Cells["CodigoMun"].Value);
            FrmCargardatosIE frm = new FrmCargardatosIE();
           frm.FormClosed += new FormClosedEventHandler(FrmCargardatos_FormClosed);
            frm.ShowDialog();
        }
    }
}
