namespace CapaPresentacionBonos
{
    partial class FrmCargardatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListado1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvListado2 = new System.Windows.Forms.DataGridView();
            this.dgvListado3 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscar2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscar3 = new System.Windows.Forms.TextBox();
            this.dgvListado4 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado4)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListado1
            // 
            this.dgvListado1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado1.Location = new System.Drawing.Point(12, 34);
            this.dgvListado1.Name = "dgvListado1";
            this.dgvListado1.Size = new System.Drawing.Size(509, 118);
            this.dgvListado1.TabIndex = 1;
            this.dgvListado1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            this.dgvListado1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            this.dgvListado1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListado1_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "(La busqueda se filtrara por el nombre o el apellido de la persona registrado(a) " +
    ")";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(12, 8);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 20);
            this.txtBuscar.TabIndex = 8;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dgvListado2
            // 
            this.dgvListado2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado2.Location = new System.Drawing.Point(12, 188);
            this.dgvListado2.Name = "dgvListado2";
            this.dgvListado2.Size = new System.Drawing.Size(509, 127);
            this.dgvListado2.TabIndex = 10;
            this.dgvListado2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado2_CellDoubleClick);
            // 
            // dgvListado3
            // 
            this.dgvListado3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado3.Location = new System.Drawing.Point(12, 355);
            this.dgvListado3.Name = "dgvListado3";
            this.dgvListado3.Size = new System.Drawing.Size(161, 123);
            this.dgvListado3.TabIndex = 11;
            this.dgvListado3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado3_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "(La busqueda se filtrara por el nombre o el apellido del tutor registrado(a) )";
            // 
            // txtBuscar2
            // 
            this.txtBuscar2.Location = new System.Drawing.Point(12, 158);
            this.txtBuscar2.Name = "txtBuscar2";
            this.txtBuscar2.Size = new System.Drawing.Size(100, 20);
            this.txtBuscar2.TabIndex = 12;
            this.txtBuscar2.TextChanged += new System.EventHandler(this.txtBuscar2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 26);
            this.label3.TabIndex = 15;
            this.label3.Text = "(La busqueda se filtrara\r\n por el nombre )";
            // 
            // txtBuscar3
            // 
            this.txtBuscar3.Location = new System.Drawing.Point(12, 322);
            this.txtBuscar3.Name = "txtBuscar3";
            this.txtBuscar3.Size = new System.Drawing.Size(100, 20);
            this.txtBuscar3.TabIndex = 14;
            this.txtBuscar3.TextChanged += new System.EventHandler(this.txtBuscar3_TextChanged);
            // 
            // dgvListado4
            // 
            this.dgvListado4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado4.Location = new System.Drawing.Point(298, 355);
            this.dgvListado4.Name = "dgvListado4";
            this.dgvListado4.Size = new System.Drawing.Size(223, 123);
            this.dgvListado4.TabIndex = 16;
            this.dgvListado4.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado4_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "(La busqueda se filtrara\r\n por el nombre )";
            // 
            // txtBuscar4
            // 
            this.txtBuscar4.Location = new System.Drawing.Point(298, 322);
            this.txtBuscar4.Name = "txtBuscar4";
            this.txtBuscar4.Size = new System.Drawing.Size(100, 20);
            this.txtBuscar4.TabIndex = 17;
            this.txtBuscar4.TextChanged += new System.EventHandler(this.txtBuscar4_TextChanged);
            // 
            // FrmCargardatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 490);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBuscar4);
            this.Controls.Add(this.dgvListado4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuscar3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBuscar2);
            this.Controls.Add(this.dgvListado3);
            this.Controls.Add(this.dgvListado2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvListado1);
            this.Name = "FrmCargardatos";
            this.Text = "FrmCargardatos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCargardatos_FormClosed);
            this.Load += new System.EventHandler(this.FrmCargardatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvListado2;
        private System.Windows.Forms.DataGridView dgvListado3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscar3;
        private System.Windows.Forms.DataGridView dgvListado4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar4;
    }
}