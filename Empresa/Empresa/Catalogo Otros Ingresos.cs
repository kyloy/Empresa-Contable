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
    public partial class Catalogo_Otros_Ingresos : Form
    {
        public Catalogo_Otros_Ingresos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtClave.ReadOnly = false;
            txtConcepto.ReadOnly = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
        }

        private void Catalogo_Otros_Ingresos_Load(object sender, EventArgs e)
        {
            dgvCatagOtrosIngre.DataSource = CatagOtrosEgreDAL.LLenar();
            dgvCatagOtrosIngre.Columns[0].Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtClave.Clear();
            txtConcepto.Clear();
            txtClave.ReadOnly = true;
            txtConcepto.ReadOnly = true;
            btnCancelar.Visible = false;
            btnGuardar.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el OTRO INGRESO Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (CatagOtrosEgreDAL.Eliminar(Convert.ToInt32(dgvCatagOtrosIngre.CurrentRow.Cells[0].Value)) > 0)
                {
                    MessageBox.Show("OTRO INGRESO Eliminado Correctamente!", "EGRESO Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCatagOtrosIngre.DataSource = CatagOtrosEgreDAL.LLenar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el OTRO INGRESO", "OTRO INGRESO No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            #region GUARDAR NUEVO
            if (Modificar == false)
            {
                CatagOtrosEgre pOtro = new CatagOtrosEgre();
                try
                {
                    pOtro.Clave = txtClave.Text.Trim();
                    pOtro.Descripcion = txtConcepto.Text.Trim();

                    int resultado = CatagOtrosEgreDAL.Agregar(pOtro);
                    if (resultado > 0)
                    {
                        dgvCatagOtrosIngre.DataSource = CatagOtrosEgreDAL.LLenar();
                        txtClave.Clear();
                        txtConcepto.Clear();
                        txtClave.ReadOnly = true;
                        txtConcepto.ReadOnly = true;
                        btnCancelar.Visible = false;
                        btnGuardar.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar El OTRO INGRESO", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion
            #region ACTUALIZAR
            else
            {
                CatagOtrosEgre pOtro = new CatagOtrosEgre();

                pOtro.idCatalogo_OtrosEgresos = Convert.ToInt32(dgvCatagOtrosIngre.CurrentRow.Cells[0].Value);
                pOtro.Clave = txtClave.Text.Trim();
                pOtro.Descripcion = txtConcepto.Text.Trim();
                if (CatagOtrosEgreDAL.Actualizar(pOtro) > 0)
                {
                    MessageBox.Show("Los datos del OTRO INGRESO se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCatagOtrosIngre.DataSource = CatagOtrosEgreDAL.LLenar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                txtClave.ReadOnly = true;
                txtConcepto.ReadOnly = true;
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;
                Modificar = false;
            }
            #endregion
        }
        bool Modificar = false;
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Modificar = true;
            txtClave.ReadOnly = false;
            txtConcepto.ReadOnly = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true; 
        }

        private void dgvCatagOtrosIngre_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CatagOtrosEgreDAL pOtro = new CatagOtrosEgreDAL();
            pOtro.Pasarcampo(dgvCatagOtrosIngre, txtClave, "Clave");
            pOtro.Pasarcampo(dgvCatagOtrosIngre, txtConcepto, "Descripcion");
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
                txtClave.Focus();
            }
        }
    }
}
