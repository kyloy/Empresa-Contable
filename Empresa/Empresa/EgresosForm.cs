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
    public partial class EgresosForm : Form
    {
        public string Titulo;
        public EgresosForm()
        {
            InitializeComponent();
        }

        private void EgresosClass_Load(object sender, EventArgs e)
        {
            dgvEgresos.DataSource = EgresosDAL.LLenar(Titulo);
            this.Text = this.Text + ": " + Titulo;
            //dgvEgresos.Columns[6].Visible = false;
            //dgvEgresos.Columns[7].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtClave.ReadOnly = false;
            txtCheque.ReadOnly = false;
            txtConcepto.ReadOnly = false;
            txtPesos.ReadOnly = false;
            txtDolar.ReadOnly = false;

            txtClave.Clear();
            txtCheque.Clear();
            txtConcepto.Clear();
            txtPesos.Text = "0";
            txtDolar.Text = "0";
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (modificar == false)
            {
                ClassEgresos pEgresos = new ClassEgresos();
                pEgresos.Clave = txtClave.Text.Trim();
                pEgresos.Cheque = txtCheque.Text.Trim();
                pEgresos.Concepto = txtConcepto.Text.Trim();
                pEgresos.Fecha = dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day;
                pEgresos.Pesos = Convert.ToInt32(txtPesos.Text.Trim());
                pEgresos.Dolar = Convert.ToInt32(txtDolar.Text.Trim());
                pEgresos.Empresa = Titulo;


                int resultado = EgresosDAL.Agregar(pEgresos);
                if (resultado > 0)
                {
                    //MessageBox.Show("Estudio Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClave.ReadOnly = true;
                    txtConcepto.ReadOnly = true;
                    txtPesos.ReadOnly = true;
                    txtDolar.ReadOnly = true;
                    txtCheque.ReadOnly = true;

                    btnGuardar.Visible = false;
                    btnCancelar.Visible = false;
                    dgvEgresos.DataSource = EgresosDAL.LLenar(Titulo);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar El EGRESO", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                btnActualizar.PerformClick();
                modificar = false;
            }
        }

        private void dgvEgresos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EgresosDAL Egre = new EgresosDAL();
            Egre.Pasarcampo(dgvEgresos, txtClave, "Clave");
            Egre.Pasarcampo(dgvEgresos, txtCheque, "Cheque");
            Egre.Pasarcampo(dgvEgresos, txtConcepto, "Concepto");
            Egre.Pasarcampo(dgvEgresos, txtPesos, "Pesos");
            Egre.Pasarcampo(dgvEgresos, txtDolar, "Dolar");
            dtpFecha.Value = Convert.ToDateTime(dgvEgresos.Rows[dgvEgresos.CurrentRow.Index].Cells[0].Value.ToString());
        }
        public bool modificar = false;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtClave.ReadOnly = false;
            txtCheque.ReadOnly = false;
            txtConcepto.ReadOnly = false;
            txtPesos.ReadOnly = false;
            txtPesos.ReadOnly = false;
            txtDolar.ReadOnly = false;
            btnActualizar.Visible = true;
            btnCancelar.Visible = true;
            modificar = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClassEgresos pEgresos = new ClassEgresos();

            pEgresos.IdEgresos = Convert.ToInt32(dgvEgresos.CurrentRow.Cells[6].Value);
            pEgresos.Clave = txtClave.Text.Trim();
            pEgresos.Cheque = txtCheque.Text.Trim();
            pEgresos.Concepto = txtConcepto.Text.Trim();
            pEgresos.Pesos = Convert.ToInt32(txtPesos.Text.Trim());
            pEgresos.Dolar = Convert.ToInt32(txtDolar.Text.Trim());
            pEgresos.Fecha = dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day;


            if (EgresosDAL.Actualizar(pEgresos) > 0)
            {
                MessageBox.Show("Los datos del EGRESO se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            btnActualizar.Visible = false;
            dgvEgresos.DataSource = EgresosDAL.LLenar(Titulo);

            txtClave.ReadOnly = true;
            txtCheque.ReadOnly = true;
            txtConcepto.ReadOnly = true;
            txtPesos.ReadOnly = true;
            txtDolar.ReadOnly = true;
            modificar = false;
        }

        private void btnBorar_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("Esta Seguro que desea eliminar el EGRESO Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (EgresosDAL.Eliminar(Convert.ToInt32(dgvEgresos.CurrentRow.Cells[6].Value)) > 0)
                {
                    MessageBox.Show("EGRESO Eliminado Correctamente!", "EGRESO Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvEgresos.DataSource = EgresosDAL.LLenar(Titulo);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el EGRESO", "EGRESO No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            //else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            //{ btnBuscar.PerformClick(); }           
            else if (e.KeyData == Keys.Enter)
            {
                txtConcepto.Focus();
            }
        }

        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            //else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            //{ btnBuscar.PerformClick(); }           
            else if (e.KeyData == Keys.Enter)
            {
                txtPesos.Focus();
            }
        }

        private void txtPesos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            //else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            //{ btnBuscar.PerformClick(); }           
            else if (e.KeyData == Keys.Enter)
            {
                txtDolar.Focus();
            }
        }

        private void txtDolar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            //else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            //{ btnBuscar.PerformClick(); }           
            else if (e.KeyData == Keys.Enter)
            {
                txtCheque.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnActualizar.Visible = false;
            txtClave.Clear();
            txtCheque.Clear();
            txtConcepto.Clear();
            txtPesos.Text = "0";
            txtDolar.Text = "0";
            txtClave.ReadOnly = true;
            txtCheque.ReadOnly = true;
            txtConcepto.ReadOnly = true;
            txtPesos.ReadOnly = true;
            txtDolar.ReadOnly = true;
            modificar = false;
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            if (CatagEgresosDAL.Buscar(txtClave.Text.Trim()) != " ")
            {
                txtConcepto.Text = CatagEgresosDAL.Buscar(txtClave.Text.Trim());
            }            
        }

        private void txtCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            //else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            //{ btnBuscar.PerformClick(); }           
            else if (e.KeyData == Keys.Enter)
            {
                txtClave.Focus();
            }
        }
    }
}
