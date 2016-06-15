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
    public partial class buscar_catalogo : Form
    {
        public buscar_catalogo()
        {
            InitializeComponent();
        }

        public bool doctor = true;
        public Doctores SeleccionDoc { get; set; }
        public Estudios SeleccionEst { get; set; }

        private void btnDoctores_Click(object sender, EventArgs e)
        {
            dgvCatalogos.DataSource = DoctoresDAL.LLenar();
            dgvCatalogos.Columns[0].Width = 60;
            dgvCatalogos.Columns[1].Width = 250;
            dgvCatalogos.Columns[0].HeaderText = "ID";
            dgvCatalogos.Columns[1].HeaderText = "Nombre Completo";
            dgvCatalogos.Columns[2].Visible = false;
            dgvCatalogos.Columns[3].Visible = false;
            dgvCatalogos.Columns[4].Visible = false;
            dgvCatalogos.Columns[7].Width = 300;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            radioButton5.Visible = true;
            txtBuscar.Focus();
            radioButton1.Checked = true;
            doctor = true;
        }

        private void buscar_catalogo_Load(object sender, EventArgs e)
        {
            dgvCatalogos.DataSource = DoctoresDAL.LLenar();
            dgvCatalogos.Columns[0].Width = 60;
            dgvCatalogos.Columns[1].Width = 250;
            dgvCatalogos.Columns[0].HeaderText = "ID";
            dgvCatalogos.Columns[1].HeaderText = "Nombre Completo";
            dgvCatalogos.Columns[2].Visible = false;
            dgvCatalogos.Columns[3].Visible = false;
            dgvCatalogos.Columns[4].Visible = false;
            dgvCatalogos.Columns[7].Width = 300;
            doctor = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            radioButton5.Visible = true;
            txtBuscar.Focus();
        }

        private void btnEstudios_Click(object sender, EventArgs e)
        {
            dgvCatalogos.DataSource = EstudiosDAL.LLenar();
            dgvCatalogos.Columns[1].Width = 150;
            doctor = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton1.Checked = true;
            txtBuscar.Focus();
        }

        int rowIndex;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (doctor == true)
            {
                dgvCatalogos.Rows[rowIndex].Selected = false;
                dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[0];
                if (radioButton1.Checked == true)
                {
                    dgvCatalogos.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 1);                    
                    foreach (DataGridViewRow row in dgvCatalogos.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[0].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvCatalogos.Rows[rowIndex].Selected = true;
                                dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[0];
                                break;
                            }
                        }
                    }            
                }
                else if (radioButton2.Checked == true)
                {
                    dgvCatalogos.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 2);
                    dgvCatalogos.Columns[2].Visible = true;
                    foreach (DataGridViewRow row in dgvCatalogos.Rows)
                    {
                        if (row.Cells[2].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[2].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvCatalogos.Rows[rowIndex].Selected = true;
                                dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[2];
                                break;
                            }
                        }
                    }
                    dgvCatalogos.Columns[2].Visible = false;
                }
                else if (radioButton3.Checked == true)
                {
                    dgvCatalogos.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 3);
                    dgvCatalogos.Columns[3].Visible = true;
                    foreach (DataGridViewRow row in dgvCatalogos.Rows)
                    {
                        if (row.Cells[3].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[3].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvCatalogos.Rows[rowIndex].Selected = true;
                                dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[3];
                                break;
                            }
                        }
                    }
                    dgvCatalogos.Columns[3].Visible = false;
                }
                else if (radioButton4.Checked == true)
                {
                    dgvCatalogos.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 4);
                    dgvCatalogos.Columns[4].Visible = true;
                    foreach (DataGridViewRow row in dgvCatalogos.Rows)
                    {
                        if (row.Cells[4].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[4].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvCatalogos.Rows[rowIndex].Selected = true;
                                dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[4];
                                break;
                            }
                        }
                    }
                    dgvCatalogos.Columns[4].Visible = false;
                }
                else if (radioButton5.Checked == true)
                {
                    dgvCatalogos.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 5);
                    foreach (DataGridViewRow row in dgvCatalogos.Rows)
                    {
                        if (row.Cells[5].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[5].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvCatalogos.Rows[rowIndex].Selected = true;
                                dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[5];
                                break;
                            }
                        }
                    }                    
                }
                else
                    MessageBox.Show("SELECCIONA UNA OPCION CORRECTA");
            }
            else
            {
                dgvCatalogos.Rows[rowIndex].Selected = false;
                dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[0];
                if (radioButton1.Checked == true)
                {
                    dgvCatalogos.DataSource = EstudiosDAL.Buscar(txtBuscar.Text, 1);
                    dgvCatalogos.Columns[1].Width = 150;
                    foreach (DataGridViewRow row in dgvCatalogos.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[0].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvCatalogos.Rows[rowIndex].Selected = true;
                                dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[0];
                                break;
                            }
                        }
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    dgvCatalogos.DataSource = EstudiosDAL.Buscar(txtBuscar.Text, 2);
                    dgvCatalogos.Columns[1].Width = 150;
                    foreach (DataGridViewRow row in dgvCatalogos.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Length >= txtBuscar.Text.Length)
                        {
                            if (row.Cells[1].Value.ToString().Substring(0, txtBuscar.Text.Length).Equals(txtBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvCatalogos.Rows[rowIndex].Selected = true;
                                dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[1];
                                break;
                            }
                        }
                    }                    
                }
            }
        }

        private void dgvCatalogos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (doctor == true)
            {
                string id = dgvCatalogos.CurrentRow.Cells[0].Value.ToString();
                SeleccionDoc = DoctoresDAL.ObtenerDoctor(id);

                this.Close();
            }
            else
            {
                int id = Convert.ToInt32(dgvCatalogos.CurrentRow.Cells[0].Value);
                SeleccionEst = EstudiosDAL.ObtenerEstudio(id);

                this.Close();
            }    
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (doctor == true)
                label1.Text = "CLAVE DOCTOR:";
            else
                label1.Text = "CLAVE ESTUDIO";
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (doctor == true)
                label1.Text = "NOMBRE:";
            else
                label1.Text = "NOMBRE";
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (doctor == true)
                label1.Text = "APE. PATERNO:";
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (doctor == true)
                label1.Text = "APE. MATERNO:";
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (doctor == true)
                label1.Text = "TELEFONO:";
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.btnBuscar.PerformClick();            
        }

        private void dgvCatalogos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (doctor == true)
                {
                    string id = dgvCatalogos.CurrentRow.Cells[0].Value.ToString();
                    SeleccionDoc = DoctoresDAL.ObtenerDoctor(id);

                    this.Close();
                }
                else
                {
                    int id = Convert.ToInt32(dgvCatalogos.CurrentRow.Cells[0].Value);
                    SeleccionEst = EstudiosDAL.ObtenerEstudio(id);

                    this.Close();
                }   
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            Catalogo_Doctores cat = new Catalogo_Doctores();
            cat.IngresoEst = true;
            cat.ShowDialog();
            this.txtBuscar.Text = cat.idDic;
        }
        
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
                dgvCatalogos.Focus(); dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex + 1].Cells[1];
            if (e.KeyData == Keys.Up)
                dgvCatalogos.Focus(); dgvCatalogos.CurrentCell = dgvCatalogos.Rows[rowIndex].Cells[1];
        }
    }
}
