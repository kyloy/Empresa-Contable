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
    public partial class Catalogo_de_Egresos : Form
    {
        public Catalogo_de_Egresos()
        {
            InitializeComponent();
        }

        private void Catalogo_de_Egresos_Load(object sender, EventArgs e)
        {
            dgvCatagEgresos.DataSource = CatagEgresosDAL.LLenar();
            dgvCatagEgresos.Columns[0].Visible = false;
        }

        private void btnNuevoEgreso_Click(object sender, EventArgs e)
        {
            txtClave.ReadOnly = false;
            txtConcepto.ReadOnly = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            #region GUARDAR NUEVO
            if (Modificar == false)
            {
                CatagEgresos pEgreso = new CatagEgresos();
                try
                {
                    pEgreso.Clave = txtClave.Text.Trim();
                    pEgreso.Descripcion = txtConcepto.Text.Trim();

                    int resultado = CatagEgresosDAL.Agregar(pEgreso);
                    if (resultado > 0)
                    {
                        dgvCatagEgresos.DataSource = CatagEgresosDAL.LLenar();
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
                    MessageBox.Show("No se pudo guardar El Ingreso", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion
            #region ACTUALIZAR
            else
            {
                CatagEgresos pEgreso = new CatagEgresos();

                pEgreso.idCatalogo_Egresos = Convert.ToInt32(dgvCatagEgresos.CurrentRow.Cells[0].Value);
                pEgreso.Clave = txtClave.Text.Trim();
                pEgreso.Descripcion = txtConcepto.Text.Trim();
                if (CatagEgresosDAL.Actualizar(pEgreso) > 0)
                {
                    MessageBox.Show("Los datos del EGRESO se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCatagEgresos.DataSource = CatagEgresosDAL.LLenar();
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
            if (MessageBox.Show("Esta Seguro que desea eliminar el EGRESO Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (CatagEgresosDAL.Eliminar(Convert.ToInt32(dgvCatagEgresos.CurrentRow.Cells[0].Value)) > 0)
                {
                    MessageBox.Show("EGRESO Eliminado Correctamente!", "EGRESO Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCatagEgresos.DataSource = CatagEgresosDAL.LLenar();      
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el EGRESO", "EGRESO No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvCatagEgresos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CatagEgresosDAL pEgresos = new CatagEgresosDAL();
            pEgresos.Pasarcampo(dgvCatagEgresos, txtClave, "Clave");
            pEgresos.Pasarcampo(dgvCatagEgresos, txtConcepto, "Descripcion");
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
                txtClave.Focus();
            }
        }
    }
}

