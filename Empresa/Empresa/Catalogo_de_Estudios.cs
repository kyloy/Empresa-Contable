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
    public partial class Catalogo_de_Estudios : Form
    {
        public Catalogo_de_Estudios()
        {
            InitializeComponent();
        }

        private void btnNuevoEstudio_Click(object sender, EventArgs e)
        {
            txtIdEstudio.Clear();
            txtDescripcion.Clear();
            txtPrecio_Pesos.Text = "0";
            txtPrecio_Dolar.Text = "0";
            txtAdeudo.Text = "0";

            txtIdEstudio.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            txtPrecio_Dolar.ReadOnly = false;
            txtPrecio_Pesos.ReadOnly = false;
            txtAdeudo.ReadOnly = false;

            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
        }

        private void Catalogo_de_Estudios_Load(object sender, EventArgs e)
        {
            dgvEstudios.DataSource = EstudiosDAL.LLenar();
            dgvEstudios.Columns[0].Width = 60;
            dgvEstudios.Columns[1].Width = 200;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                Estudios pEstudios = new Estudios();
                pEstudios.IdEstudios = Convert.ToInt32(txtIdEstudio.Text.Trim());
                pEstudios.Descripcion = txtDescripcion.Text.Trim();
                pEstudios.Precio_Pesos = Convert.ToInt32(txtPrecio_Pesos.Text.Trim());
                pEstudios.Precio_Dolar = Convert.ToInt32(txtPrecio_Dolar.Text.Trim());
                pEstudios.Adeudo = Convert.ToInt32(txtAdeudo.Text.Trim());


                int resultado = EstudiosDAL.Agregar(pEstudios);
                if (resultado > 0)
                {
                    //MessageBox.Show("Estudio Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdEstudio.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    txtPrecio_Pesos.ReadOnly = true;
                    txtPrecio_Pesos.ReadOnly = true;
                    txtPrecio_Dolar.ReadOnly = true;
                    txtAdeudo.ReadOnly = true;

                    btnGuardar.Visible = false;
                    btnCancelar.Visible = false;
                    dgvEstudios.DataSource = EstudiosDAL.LLenar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar El Estudio", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                btnActualizar.PerformClick();
                Modificar = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdEstudio.Clear();
            txtDescripcion.Clear();
            txtPrecio_Pesos.Text = "0";
            txtPrecio_Dolar.Text = "0";
            txtAdeudo.Text = "0";

            txtIdEstudio.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            txtPrecio_Pesos.ReadOnly = true;
            txtPrecio_Pesos.ReadOnly = true;
            txtPrecio_Dolar.ReadOnly = true;
            txtAdeudo.ReadOnly = true;

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            Modificar = false;
        }
        bool Modificar = false;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtIdEstudio.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            txtPrecio_Dolar.ReadOnly = false;
            txtPrecio_Pesos.ReadOnly = false;
            txtAdeudo.ReadOnly = false;

            btnActualizar.Visible = true;
            Modificar = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estudios pEstudios = new Estudios();

            pEstudios.IdEstudios = Convert.ToInt32(dgvEstudios.CurrentRow.Cells[0].Value);
            pEstudios.Descripcion = txtDescripcion.Text.Trim();
            pEstudios.Precio_Pesos = Convert.ToInt32(txtPrecio_Pesos.Text.Trim());
            pEstudios.Precio_Dolar = Convert.ToInt32(txtPrecio_Dolar.Text.Trim());
            pEstudios.Adeudo = Convert.ToInt32(txtAdeudo.Text.Trim()); ;

            if (EstudiosDAL.Actualizar(pEstudios) > 0)
            {
                MessageBox.Show("Los datos del Estudio se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            btnActualizar.Visible = false;
            dgvEstudios.DataSource = EstudiosDAL.LLenar();

            txtIdEstudio.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            txtPrecio_Pesos.ReadOnly = true;
            txtPrecio_Pesos.ReadOnly = true;
            txtPrecio_Dolar.ReadOnly = true;
            txtAdeudo.ReadOnly = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Estudio Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (EstudiosDAL.Eliminar(Convert.ToInt32(dgvEstudios.CurrentRow.Cells[0].Value)) > 0)
                {
                    MessageBox.Show("Estudio Eliminado Correctamente!", "Estudio Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvEstudios.DataSource = EstudiosDAL.LLenar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Estudio", "Estudio No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvEstudios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EstudiosDAL estu = new EstudiosDAL();
            estu.Pasarcampo(dgvEstudios, txtIdEstudio, "idEstudios");
            estu.Pasarcampo(dgvEstudios, txtDescripcion, "Descripcion");
            estu.Pasarcampo(dgvEstudios, txtPrecio_Pesos, "Precio_pesos");
            estu.Pasarcampo(dgvEstudios, txtPrecio_Dolar, "Precio_dolar");
            estu.Pasarcampo(dgvEstudios, txtAdeudo, "Adeudo"); 
        }

        int rowIndex;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEstudios.Rows[rowIndex].Selected = false;
            dgvEstudios.CurrentCell = dgvEstudios.Rows[rowIndex].Cells[0];

            if (radioButton1.Checked == true)
            {
                foreach (DataGridViewRow row in dgvEstudios.Rows)
                {
                    if (row.Cells[0].Value.ToString().Length >= txtBuscar.Text.Length)
                    {
                        if (row.Cells[0].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                        {
                            rowIndex = row.Index;
                            dgvEstudios.Rows[rowIndex].Selected = true;
                            dgvEstudios.CurrentCell = dgvEstudios.Rows[rowIndex].Cells[0];
                            break;
                        }
                    }
                }
            }
            else if (radioButton2.Checked == true)
            {
                foreach (DataGridViewRow row in dgvEstudios.Rows)
                {
                    if (row.Cells[1].Value.ToString().Length >= txtBuscar.Text.Length)
                    {
                        if (row.Cells[1].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                        {
                            rowIndex = row.Index;
                            dgvEstudios.Rows[rowIndex].Selected = true;
                            dgvEstudios.CurrentCell = dgvEstudios.Rows[rowIndex].Cells[1];
                            break;
                        }
                    }
                }
            }
            else
            {

            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
                btnGuardar.PerformClick();
            else if (e.KeyData == Keys.Enter)
                txtPrecio_Pesos.Focus();
        }

        private void txtPrecio_Dolar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
                btnGuardar.PerformClick();
            else if (e.KeyData == Keys.Enter)
                txtAdeudo.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdEstudio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
                btnGuardar.PerformClick();
            else if (e.KeyData == Keys.Enter)
                txtDescripcion.Focus();       
        }

        private void txtAdeudo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
                btnGuardar.PerformClick();
            else if (e.KeyData == Keys.Enter)
                txtIdEstudio.Focus();         
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }

        private void txtPrecio_Pesos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
                btnGuardar.PerformClick();
            else if (e.KeyData == Keys.Enter)
                txtPrecio_Dolar.Focus();
        }
    }
}
