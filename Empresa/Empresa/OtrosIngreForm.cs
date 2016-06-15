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
    public partial class OtrosIngreForm : Form
    {
        public string Titulo;
        public OtrosIngreForm()
        {
            InitializeComponent();
        }

        private void OtrosIngreForm_Load(object sender, EventArgs e)
        {
            dgvOtrosIngre.DataSource = OtrosEgresosDAL.LLenar(Titulo);
            //this.Text = this.Text + ": " + Titulo;
            dgvOtrosIngre.Columns[5].Visible = false;
            dgvOtrosIngre.Columns[6].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtClave.ReadOnly = false;           
            txtConcepto.ReadOnly = false;
            txtPesos.ReadOnly = false;
            txtDolar.ReadOnly = false;

            txtClave.Clear();           
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
                ClassOtrosEgre pOtro = new ClassOtrosEgre();
                pOtro.Clave = txtClave.Text.Trim();                
                pOtro.Concepto = txtConcepto.Text.Trim();
                pOtro.Fecha = dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day;
                pOtro.Pesos = Convert.ToInt32(txtPesos.Text.Trim());
                pOtro.Dolar = Convert.ToInt32(txtDolar.Text.Trim());
                pOtro.Empresa = Titulo;


                int resultado = OtrosEgresosDAL.Agregar(pOtro);
                if (resultado > 0)
                {
                    //MessageBox.Show("Estudio Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClave.ReadOnly = true;
                    txtConcepto.ReadOnly = true;
                    txtPesos.ReadOnly = true;
                    txtDolar.ReadOnly = true;                   

                    btnGuardar.Visible = false;
                    btnCancelar.Visible = false;
                    dgvOtrosIngre.DataSource = OtrosEgresosDAL.LLenar(Titulo);
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

        private void btnBorar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el OTROS INGRESOS Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (OtrosEgresosDAL.Eliminar(Convert.ToInt32(dgvOtrosIngre.CurrentRow.Cells[5].Value)) > 0)
                {
                    MessageBox.Show("OTROS INGRESOS Eliminado Correctamente!", "OTROS INGRESOS Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvOtrosIngre.DataSource = OtrosEgresosDAL.LLenar(Titulo);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el OTROS INGRESOS", "OTROS INGRESOS No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public bool modificar = false;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtClave.ReadOnly = false;            
            txtConcepto.ReadOnly = false;
            txtPesos.ReadOnly = false;
            txtPesos.ReadOnly = false;
            txtDolar.ReadOnly = false;
            btnActualizar.Visible = true;
            btnCancelar.Visible = true;
            btnGuardar.Visible = true;
            modificar = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnActualizar.Visible = false;
            txtClave.Clear();          
            txtConcepto.Clear();
            txtPesos.Text = "0";
            txtDolar.Text = "0";
            txtClave.ReadOnly = true;           
            txtConcepto.ReadOnly = true;
            txtPesos.ReadOnly = true;
            txtDolar.ReadOnly = true;
            modificar = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvOtrosIngre_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OtrosEgresosDAL pOtro = new OtrosEgresosDAL();
            pOtro.Pasarcampo(dgvOtrosIngre, txtClave, "Clave");
            pOtro.Pasarcampo(dgvOtrosIngre, txtConcepto, "Concepto");
            pOtro.Pasarcampo(dgvOtrosIngre, txtPesos, "Pesos");
            pOtro.Pasarcampo(dgvOtrosIngre, txtDolar, "Dolar");
            dtpFecha.Value = Convert.ToDateTime(dgvOtrosIngre.Rows[dgvOtrosIngre.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            ClassOtrosEgre pOtro = new ClassOtrosEgre();

            pOtro.idOtros = Convert.ToInt32(dgvOtrosIngre.CurrentRow.Cells[5].Value);
            pOtro.Clave = txtClave.Text.Trim();
            pOtro.Concepto = txtConcepto.Text.Trim();
            pOtro.Pesos = Convert.ToInt32(txtPesos.Text.Trim());
            pOtro.Dolar = Convert.ToInt32(txtDolar.Text.Trim());
            pOtro.Fecha = dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day;


            if (OtrosEgresosDAL.Actualizar(pOtro) > 0)
            {
                MessageBox.Show("Los datos del OTRO INGRESO se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            btnActualizar.Visible = false;
            dgvOtrosIngre.DataSource = OtrosEgresosDAL.LLenar(Titulo);

            txtClave.ReadOnly = true;            
            txtConcepto.ReadOnly = true;
            txtPesos.ReadOnly = true;
            txtDolar.ReadOnly = true;
            modificar = false;
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
                txtClave.Focus();
            }
        }
    }
}
