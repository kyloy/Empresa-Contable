using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa
{
    public partial class Editar_Adeudo : Form
    {
        public string Titulo;
        public string Fecha_incio;
        public string Fecha_final;
        public string Doctor;
        public Editar_Adeudo()
        {
            InitializeComponent();
        }

        private void Editar_Adeudo_Load(object sender, EventArgs e)
        {
            List<EditarAdeudo> reporte = new List<EditarAdeudo>();            
            reporte = EditarAdeudoDAL.LLenar(Fecha_incio, Fecha_final, Doctor, Titulo);
            try
            {
                lbDoctor.Text = reporte[0].Nombre_Doctor;
                lbEmpresa.Text = reporte[0].Empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: No existen registros...");
            }
            lbFecha.Text = String.Format("DEL {0} AL {1}", Fecha_incio, Fecha_final);
            dgvEditar_Adeudo.DataSource = reporte;
            dgvEditar_Adeudo.Columns[0].HeaderText = "No.";
            dgvEditar_Adeudo.Columns[0].Width = 30;
            dgvEditar_Adeudo.Columns[1].Width = 220;
            dgvEditar_Adeudo.Columns[2].Width = 150;
            dgvEditar_Adeudo.Columns[3].Width = 75;
            dgvEditar_Adeudo.Columns[13].HeaderText = "PESOS";
            dgvEditar_Adeudo.Columns[14].HeaderText = "DOLAR";
            //dgvEditar_Adeudo.Columns[1].Width = 50;
            dgvEditar_Adeudo.Columns[13].Width = 50;
            dgvEditar_Adeudo.Columns[14].Width = 50;
            dgvEditar_Adeudo.Columns[5].Visible = false;
            dgvEditar_Adeudo.Columns[6].Visible = false;
            dgvEditar_Adeudo.Columns[7].Visible = false;
            dgvEditar_Adeudo.Columns[8].Visible = false;
            dgvEditar_Adeudo.Columns[9].Visible = false;
            dgvEditar_Adeudo.Columns[10].Visible = false;
            dgvEditar_Adeudo.Columns[11].Visible = false;
            dgvEditar_Adeudo.Columns[12].Visible = false;
        }

        private void dgvEditar_Adeudo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {            
            this.dgvEditar_Adeudo.Rows[e.RowIndex].Cells[0].Value
            = (e.RowIndex + 1).ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el PACIENTE Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ingre_EstudiosDAL.Eliminar(Convert.ToInt32(dgvEditar_Adeudo.CurrentRow.Cells[12].Value)) > 0)
                {
                    MessageBox.Show("PACIENTE Eliminado Correctamente!", "PACIENTE Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvEditar_Adeudo.DataSource = EditarAdeudoDAL.LLenar(Fecha_incio, Fecha_final, Doctor, Titulo);                  

                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el PACIENTE", "PACIENTE No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvEditar_Adeudo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Ingre_EstudiosDAL ingre = new Ingre_EstudiosDAL();
            ingre.Pasarcampo(dgvEditar_Adeudo, txtPaciente, "Nombre_Paciente");
            ingre.Pasarcampo(dgvEditar_Adeudo, txtPesos, "Precio_Pesos");
            ingre.Pasarcampo(dgvEditar_Adeudo, txtDolar, "Precio_Dolar");
            ingre.Pasarcampo(dgvEditar_Adeudo, txtAdeudo, "Adeudo");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            txtPaciente.ReadOnly = false;
            txtPesos.ReadOnly = false;
            txtDolar.ReadOnly = false;
            txtAdeudo.ReadOnly = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtAdeudo.Text == "")
                txtAdeudo.Text = "0";
            if (txtPesos.Text == "")
                txtPesos.Text = "0";
            if (txtDolar.Text == "")
                txtDolar.Text = "0";

            try
            {
                if (EditarAdeudoDAL.Actualizar(Convert.ToInt32(txtDolar.Text), Convert.ToInt32(txtPesos.Text), Convert.ToInt32(txtAdeudo.Text), txtPaciente.Text, Convert.ToInt32(dgvEditar_Adeudo.CurrentRow.Cells[12].Value))  > 0)
                {
                    MessageBox.Show("Los datos del INGRESO se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvEditar_Adeudo.DataSource = EditarAdeudoDAL.LLenar(Fecha_incio, Fecha_final, Doctor, Titulo);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                btnGuardar.Visible = false;
                txtPaciente.ReadOnly = true;
                txtPesos.ReadOnly = true;
                txtDolar.ReadOnly = true;
                txtAdeudo.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar El Ingreso", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(ex.Message);
            }
        }        
    }
}
