namespace Empresa
{
    partial class Editar_Adeudo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEditar_Adeudo = new System.Windows.Forms.DataGridView();
            this.lbDoctor = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lbEmpresa = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdeudo = new System.Windows.Forms.TextBox();
            this.txtDolar = new System.Windows.Forms.TextBox();
            this.txtPesos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditar_Adeudo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEditar_Adeudo
            // 
            this.dgvEditar_Adeudo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvEditar_Adeudo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEditar_Adeudo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEditar_Adeudo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEditar_Adeudo.Location = new System.Drawing.Point(33, 107);
            this.dgvEditar_Adeudo.Name = "dgvEditar_Adeudo";
            this.dgvEditar_Adeudo.RowTemplate.ReadOnly = true;
            this.dgvEditar_Adeudo.Size = new System.Drawing.Size(723, 392);
            this.dgvEditar_Adeudo.TabIndex = 1;
            this.dgvEditar_Adeudo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEditar_Adeudo_CellMouseClick);
            this.dgvEditar_Adeudo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvEditar_Adeudo_RowPostPaint);
            // 
            // lbDoctor
            // 
            this.lbDoctor.AutoSize = true;
            this.lbDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoctor.Location = new System.Drawing.Point(381, 42);
            this.lbDoctor.Name = "lbDoctor";
            this.lbDoctor.Size = new System.Drawing.Size(133, 20);
            this.lbDoctor.TabIndex = 2;
            this.lbDoctor.Text = "nombre_Doctor";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(30, 42);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(345, 20);
            this.lbTitulo.TabIndex = 3;
            this.lbTitulo.Text = "REPORTE DE ADEUDOS DEL DOCTOR: ";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.Location = new System.Drawing.Point(30, 72);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(54, 20);
            this.lbFecha.TabIndex = 4;
            this.lbFecha.Text = "fecha";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(651, 609);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(105, 28);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lbEmpresa
            // 
            this.lbEmpresa.AutoSize = true;
            this.lbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmpresa.Location = new System.Drawing.Point(197, 9);
            this.lbEmpresa.Name = "lbEmpresa";
            this.lbEmpresa.Size = new System.Drawing.Size(95, 20);
            this.lbEmpresa.TabIndex = 6;
            this.lbEmpresa.Text = "EMPRESA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(541, 517);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "ADEUDO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(435, 517);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "DOLAR";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(329, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "PESOS";
            // 
            // txtAdeudo
            // 
            this.txtAdeudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdeudo.Location = new System.Drawing.Point(545, 540);
            this.txtAdeudo.Name = "txtAdeudo";
            this.txtAdeudo.ReadOnly = true;
            this.txtAdeudo.Size = new System.Drawing.Size(100, 26);
            this.txtAdeudo.TabIndex = 39;
            this.txtAdeudo.Text = "0";
            // 
            // txtDolar
            // 
            this.txtDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDolar.Location = new System.Drawing.Point(439, 540);
            this.txtDolar.Name = "txtDolar";
            this.txtDolar.ReadOnly = true;
            this.txtDolar.Size = new System.Drawing.Size(100, 26);
            this.txtDolar.TabIndex = 38;
            this.txtDolar.Text = "0";
            // 
            // txtPesos
            // 
            this.txtPesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesos.Location = new System.Drawing.Point(333, 540);
            this.txtPesos.Name = "txtPesos";
            this.txtPesos.ReadOnly = true;
            this.txtPesos.Size = new System.Drawing.Size(100, 26);
            this.txtPesos.TabIndex = 37;
            this.txtPesos.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "NOMBRE DEL PACIENTE";
            // 
            // txtPaciente
            // 
            this.txtPaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.Location = new System.Drawing.Point(33, 540);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(294, 26);
            this.txtPaciente.TabIndex = 43;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(273, 609);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 28);
            this.btnModificar.TabIndex = 45;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(162, 609);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(105, 28);
            this.btnGuardar.TabIndex = 46;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Editar_Adeudo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 649);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAdeudo);
            this.Controls.Add(this.txtDolar);
            this.Controls.Add(this.txtPesos);
            this.Controls.Add(this.lbEmpresa);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbDoctor);
            this.Controls.Add(this.dgvEditar_Adeudo);
            this.Name = "Editar_Adeudo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDITAR ADEUDO";
            this.Load += new System.EventHandler(this.Editar_Adeudo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditar_Adeudo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEditar_Adeudo;
        private System.Windows.Forms.Label lbDoctor;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lbEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAdeudo;
        private System.Windows.Forms.TextBox txtDolar;
        private System.Windows.Forms.TextBox txtPesos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
    }
}