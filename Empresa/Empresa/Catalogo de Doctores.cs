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
    public partial class Catalogo_Doctores : Form
    {
        public Catalogo_Doctores()
        {
            InitializeComponent();
        }

        private void Catalogo_Doctores_Load(object sender, EventArgs e)
        {
            dgvDoctores.DataSource = DoctoresDAL.LLenar();
            dgvDoctores.Columns[0].Width = 60;
            dgvDoctores.Columns[1].Width = 200;
            dgvDoctores.Columns[0].HeaderText = "ID";
            dgvDoctores.Columns[1].HeaderText = "Nombre Completo";
            dgvDoctores.Columns[2].Visible = false;
            dgvDoctores.Columns[3].Visible = false;
            dgvDoctores.Columns[4].Visible = false;
            dgvDoctores.Columns[7].Width = 250;
            dgvDoctores.CurrentCell = dgvDoctores.Rows[dgvDoctores.RowCount - 1].Cells[0];
        }

        private void btnNuevodoctor_Click(object sender, EventArgs e)
        {
            txtIdoctor.Clear();
            txtNombre.Clear();
            txtApellido_paterno.Clear();
            txtApellido_Materno.Clear();
            txtDireccion.Clear();
            txtColonia.Clear();
            txtZona.Clear();
            txtTelefono.Clear();
            txtCelular.Clear();
            txtAseguranza.Clear();

            txtIdoctor.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtApellido_paterno.ReadOnly = false;
            txtApellido_Materno.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtColonia.ReadOnly = false;
            txtCiudad.ReadOnly = false;
            txtEstado.ReadOnly = false;
            txtPais.ReadOnly = false;
            txtZona.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCelular.ReadOnly = false;
            txtAseguranza.ReadOnly = false;

            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
        }
        public bool IngresoEst = false;
        public string idDic = "";
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                Doctores pDoctores = new Doctores();
                try
                {
                    pDoctores.IdDoctor = txtIdoctor.Text.Trim();
                    pDoctores.Nombre = txtNombre.Text.Trim();
                    pDoctores.Apellido_Paterno = txtApellido_paterno.Text.Trim();
                    pDoctores.Apellido_Materno = txtApellido_Materno.Text.Trim();
                    pDoctores.Direccion = txtDireccion.Text.Trim();
                    pDoctores.Colonia = txtColonia.Text.Trim();
                    pDoctores.Ciudad = txtCiudad.Text.Trim();
                    pDoctores.Estado = txtEstado.Text.Trim();
                    pDoctores.Pais = txtPais.Text.Trim();
                    pDoctores.Zona = txtZona.Text.Trim();
                    pDoctores.Telefono = txtTelefono.Text.Trim();
                    pDoctores.Celular = txtCelular.Text.Trim();
                    pDoctores.Aseguranza = txtAseguranza.Text.Trim();

                    int resultado = DoctoresDAL.Agregar(pDoctores);
                    if (resultado > 0)
                    {
                        //MessageBox.Show("Doctor Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdoctor.ReadOnly = true;
                        txtNombre.ReadOnly = true;
                        txtApellido_paterno.ReadOnly = true;
                        txtApellido_Materno.ReadOnly = true;
                        txtDireccion.ReadOnly = true;
                        txtColonia.ReadOnly = true;
                        txtCiudad.ReadOnly = true;
                        txtEstado.ReadOnly = true;
                        txtPais.ReadOnly = true;
                        txtZona.ReadOnly = true;
                        txtTelefono.ReadOnly = true;
                        txtCelular.ReadOnly = true;
                        txtAseguranza.ReadOnly = true;

                        btnGuardar.Visible = false;
                        btnCancelar.Visible = false;
                        if (IngresoEst == true)
                        {
                            idDic = txtIdoctor.Text;
                            this.Close();
                        }
                        dgvDoctores.DataSource = DoctoresDAL.LLenar();
                        dgvDoctores.Columns[0].Width = 60;
                        dgvDoctores.Columns[1].Width = 200;
                        dgvDoctores.Columns[0].HeaderText = "ID";
                        dgvDoctores.Columns[1].HeaderText = "Nombre Completo";
                        dgvDoctores.Columns[2].Visible = false;
                        dgvDoctores.Columns[3].Visible = false;
                        dgvDoctores.Columns[4].Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar El Doctor", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                btnActualizar.PerformClick();
                Modificar = false;
            }
            //if (IngresoEst == true)
            //{
            //    idDic = txtIdoctor.Text;
            //    this.Close();
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdoctor.Clear();
            txtNombre.Clear();
            txtApellido_paterno.Clear();
            txtApellido_Materno.Clear();
            txtDireccion.Clear();
            txtColonia.Clear();
            txtCiudad.Text = "TIJUANA";
            txtEstado.Text = "BAJA CALIFORNOIA";
            txtPais.Text = "MEXICO";
            txtZona.Clear();
            txtTelefono.Clear();
            txtCelular.Clear();
            txtAseguranza.Clear();

            txtIdoctor.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtApellido_paterno.ReadOnly = true;
            txtApellido_Materno.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtColonia.ReadOnly = true;
            txtCiudad.ReadOnly = true;
            txtEstado.ReadOnly = true;
            txtPais.ReadOnly = true;
            txtZona.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCelular.ReadOnly = true;
            txtAseguranza.ReadOnly = true;

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            Modificar = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Cliente Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DoctoresDAL.Eliminar((dgvDoctores.CurrentRow.Cells[0].Value).ToString()) > 0)
                {
                    MessageBox.Show("Doctor Eliminado Correctamente!", "Doctor Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDoctores.DataSource = DoctoresDAL.LLenar();
                    dgvDoctores.Columns[0].Width = 60;
                    dgvDoctores.Columns[1].Width = 200;
                    dgvDoctores.Columns[0].HeaderText = "ID";
                    dgvDoctores.Columns[1].HeaderText = "Nombre Completo";
                    dgvDoctores.Columns[2].Visible = false;
                    dgvDoctores.Columns[3].Visible = false;
                    dgvDoctores.Columns[4].Visible = false;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Doctor", "Doctor No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Doctores pDoctores = new Doctores();

            pDoctores.IdDoctor = (dgvDoctores.CurrentRow.Cells[0].Value).ToString();
            pDoctores.Nombre = txtNombre.Text.Trim();
            pDoctores.Apellido_Paterno = txtApellido_paterno.Text.Trim();
            pDoctores.Apellido_Materno = txtApellido_Materno.Text.Trim();
            pDoctores.Direccion = txtDireccion.Text.Trim();
            pDoctores.Colonia = txtColonia.Text.Trim();
            pDoctores.Ciudad = txtCiudad.Text.Trim();
            pDoctores.Estado = txtEstado.Text.Trim();
            pDoctores.Pais = txtPais.Text.Trim();
            pDoctores.Zona = txtPais.Text.Trim();
            pDoctores.Telefono = txtTelefono.Text.Trim();
            pDoctores.Celular = txtCelular.Text.Trim();
            pDoctores.Aseguranza = txtAseguranza.Text.Trim();

            if (DoctoresDAL.Actualizar(pDoctores) > 0)
            {               
                MessageBox.Show("Los datos del Doctor se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (IngresoEst == true)
                {
                    idDic = txtIdoctor.Text;
                    this.Close();
                }
                dgvDoctores.DataSource = DoctoresDAL.LLenar();
                dgvDoctores.Columns[0].Width = 60;
                dgvDoctores.Columns[1].Width = 200;
                dgvDoctores.Columns[0].HeaderText = "ID";
                dgvDoctores.Columns[1].HeaderText = "Nombre Completo";
                dgvDoctores.Columns[2].Visible = false;
                dgvDoctores.Columns[3].Visible = false;
                dgvDoctores.Columns[4].Visible = false;
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            btnActualizar.Visible = false;
            dgvDoctores.DataSource = DoctoresDAL.LLenar();
            dgvDoctores.Columns[0].Width = 60;
            dgvDoctores.Columns[1].Width = 200;
            dgvDoctores.Columns[0].HeaderText = "ID";
            dgvDoctores.Columns[1].HeaderText = "Nombre Completo";
            dgvDoctores.Columns[2].Visible = false;
            dgvDoctores.Columns[3].Visible = false;
            dgvDoctores.Columns[4].Visible = false;
            txtIdoctor.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtApellido_paterno.ReadOnly = true;
            txtApellido_Materno.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtColonia.ReadOnly = true;
            txtCiudad.ReadOnly = true;
            txtEstado.ReadOnly = true;
            txtPais.ReadOnly = true;
            txtZona.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCelular.ReadOnly = true;
            txtAseguranza.ReadOnly = true;            
        }
        bool Modificar = false;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtIdoctor.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtApellido_paterno.ReadOnly = false;
            txtApellido_Materno.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtColonia.ReadOnly = false;
            txtCiudad.ReadOnly = false;
            txtEstado.ReadOnly = false;
            txtPais.ReadOnly = false;
            txtZona.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCelular.ReadOnly = false;
            txtAseguranza.ReadOnly = false;

            btnActualizar.Visible = true;
            Modificar = true;
        }

        int rowIndex;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDoctores.Rows[rowIndex].Selected = false;
                dgvDoctores.CurrentCell = dgvDoctores.Rows[rowIndex].Cells[0];
                if (radioButton1.Checked == true)
                {
                    dgvDoctores.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 1);
                    foreach (DataGridViewRow row in dgvDoctores.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[0].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvDoctores.Rows[rowIndex].Selected = true;
                                dgvDoctores.CurrentCell = dgvDoctores.Rows[rowIndex].Cells[0];
                                break;
                            }
                        }
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    dgvDoctores.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 2);
                    dgvDoctores.Columns[2].Visible = true;
                    foreach (DataGridViewRow row in dgvDoctores.Rows)
                    {
                        if (row.Cells[2].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[2].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvDoctores.Rows[rowIndex].Selected = true;
                                dgvDoctores.CurrentCell = dgvDoctores.Rows[rowIndex].Cells[2];
                                break;
                            }
                        }
                    }
                    dgvDoctores.Columns[2].Visible = false;
                }
                else if (radioButton3.Checked == true)
                {
                    dgvDoctores.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 3);
                    dgvDoctores.Columns[3].Visible = true;
                    foreach (DataGridViewRow row in dgvDoctores.Rows)
                    {
                        if (row.Cells[3].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[3].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvDoctores.Rows[rowIndex].Selected = true;
                                dgvDoctores.CurrentCell = dgvDoctores.Rows[rowIndex].Cells[3];
                                break;
                            }
                        }
                    }
                    dgvDoctores.Columns[3].Visible = false;
                }
                else if (radioButton4.Checked == true)
                {
                    dgvDoctores.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 4);
                    dgvDoctores.Columns[4].Visible = true;
                    foreach (DataGridViewRow row in dgvDoctores.Rows)
                    {
                        if (row.Cells[4].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[4].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvDoctores.Rows[rowIndex].Selected = true;
                                dgvDoctores.CurrentCell = dgvDoctores.Rows[rowIndex].Cells[4];
                                break;
                            }
                        }
                    }
                    dgvDoctores.Columns[4].Visible = false;
                }
                else if (radioButton5.Checked == true)
                {
                    dgvDoctores.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 5);
                    foreach (DataGridViewRow row in dgvDoctores.Rows)
                    {
                        if (row.Cells[5].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[5].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvDoctores.Rows[rowIndex].Selected = true;
                                dgvDoctores.CurrentCell = dgvDoctores.Rows[rowIndex].Cells[5];
                                break;
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("SELECCIONA UNA OPCION CORRECTA");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtBuscar.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDoctores_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DoctoresDAL docs = new DoctoresDAL();
            docs.Pasarcampo(dgvDoctores, txtIdoctor, "idDoctor");
            docs.Pasarcampo(dgvDoctores, txtNombre, "Nombre");
            docs.Pasarcampo(dgvDoctores, txtApellido_paterno, "Apellido_paterno");
            docs.Pasarcampo(dgvDoctores, txtApellido_Materno, "Apellido_materno");
            docs.Pasarcampo(dgvDoctores, txtDireccion, "Direccion");
            docs.Pasarcampo(dgvDoctores, txtColonia, "Colonia");
            docs.Pasarcampo(dgvDoctores, txtCiudad, "Ciudad");
            docs.Pasarcampo(dgvDoctores, txtEstado, "Estado");
            docs.Pasarcampo(dgvDoctores, txtPais, "Pais");
            docs.Pasarcampo(dgvDoctores, txtZona, "Zona");
            docs.Pasarcampo(dgvDoctores, txtTelefono, "Telefono");
            docs.Pasarcampo(dgvDoctores, txtCelular, "Celular");
            docs.Pasarcampo(dgvDoctores, txtAseguranza, "Aseguranza");            
        }

        private void txtAseguranza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtIdoctor.Focus(); } 
        }

        private void txtCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtAseguranza.Focus(); }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtCelular.Focus(); }          
        }

        private void txtApellido_Materno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtDireccion.Focus(); }                     
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtColonia.Focus(); }            
        }

        private void txtColonia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtCiudad.Focus(); }            
        }

        private void txtIdoctor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }

        private void txtIdoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtNombre.Focus(); }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtApellido_paterno.Focus(); }
        }

        private void txtCiudad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtEstado.Focus(); }
        }

        private void txtEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtPais.Focus();}
        }

        private void txtPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            {txtZona.Focus();}
        }

        private void txtZona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            {txtTelefono.Focus();}
        }

        private void txtApellido_paterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.Enter)
            { txtApellido_Materno.Focus(); }
        }

        private void dgvDoctores_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Down)
            {
                //dgvDoctores.CellMouseClick();
            }
        }

        private void dgvDoctores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDoctores.Focus() == true)
            {
                DoctoresDAL docs = new DoctoresDAL();
                docs.Pasarcampo(dgvDoctores, txtIdoctor, "idDoctor");
                docs.Pasarcampo(dgvDoctores, txtNombre, "Nombre");
                docs.Pasarcampo(dgvDoctores, txtApellido_paterno, "Apellido_paterno");
                docs.Pasarcampo(dgvDoctores, txtApellido_Materno, "Apellido_materno");
                docs.Pasarcampo(dgvDoctores, txtDireccion, "Direccion");
                docs.Pasarcampo(dgvDoctores, txtColonia, "Colonia");
                docs.Pasarcampo(dgvDoctores, txtCiudad, "Ciudad");
                docs.Pasarcampo(dgvDoctores, txtEstado, "Estado");
                docs.Pasarcampo(dgvDoctores, txtPais, "Pais");
                docs.Pasarcampo(dgvDoctores, txtZona, "Zona");
                docs.Pasarcampo(dgvDoctores, txtTelefono, "Telefono");
                docs.Pasarcampo(dgvDoctores, txtCelular, "Celular");
                docs.Pasarcampo(dgvDoctores, txtAseguranza, "Aseguranza");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImpDoctores doct = new ImpDoctores();
            this.Hide();
            doct.ShowDialog();            
            this.Show();
        }
    }
}
